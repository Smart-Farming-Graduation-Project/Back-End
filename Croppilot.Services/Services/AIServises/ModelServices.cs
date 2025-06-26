using Croppilot.Date.Models.AiModel;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract.AiSerives;
using Croppilot.Services.Abstract.EmbbeddedServices;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using SkiaSharp;
using Yolov7net;

namespace Croppilot.Services.Services.AIServises
{
    public class ModelServices : IModelServices
    {
        private readonly IUnitOfWork _unit;
        private readonly IChatService _chatService;
        private readonly IAzureBlobStorageService _azureBlobStorageService;
        private readonly IConfiguration _configuration;
        private readonly Yolov8 _yolov8;
        private readonly InferenceSession _mobilenetSession;
        private readonly IRoverPhotoServices _roverPhotoServices;
        private readonly string[] _customLabels;
        public ModelServices(IUnitOfWork unit, IChatService chatService, IRoverPhotoServices roverPhotoServices, IConfiguration configuration)
        {
            _unit = unit;
            _chatService = chatService;
            _roverPhotoServices = roverPhotoServices;

            _configuration = configuration;

            // Load the Models
            var yoloModelPath = Path.Combine(_configuration["AiModels:YoloModelPath"]);
            var mobilenetModelPath = Path.Combine(_configuration["AiModels:MobileNetModelPath"]);
            _yolov8 = new Yolov8(yoloModelPath, useCuda: false);

            _customLabels = new string[]
            {
                "Early Blight", "Healthy", "Late Blight", "Leaf Miner", "Leaf Mold",
                "Mosaic Virus", "Septoria", "Spider Mites", "Yellow Leaf Curl Virus"
            };
            _yolov8.SetupLabels(_customLabels);


            _mobilenetSession = new InferenceSession(mobilenetModelPath);


        }
        public async Task<ModelResult> UploadPhotoToModel(IFormFile image)
        {

            using (var stream = new MemoryStream())
            {
                await image.CopyToAsync(stream);

                var fileBytes = stream.ToArray();

                using (var skImage = SKImage.FromEncodedData(fileBytes))
                using (var skBitmap = SKBitmap.FromImage(skImage))
                {
                    var predictions = _yolov8.Predict(skBitmap, conf_thres: 0.5f, iou_thres: 0.45f);

                    var feedbackDict = new Dictionary<string, string>();

                    var imageId = Guid.NewGuid();
                    var modelResult = new ModelResult
                    {
                        ImageId = imageId,
                        ImageUrl = "",
                        FeedbackEntries = new List<FeedbackEntry>()
                    };

                    foreach (var prediction in predictions)
                    {
                        var rect = prediction.Rectangle;
                        var croppedImage = CropImage(skBitmap, rect);

                        // Preprocess the cropped image for MobileNet
                        var inputTensor = PreprocessImageForMobileNet(croppedImage);

                        // Run MobileNet inference
                        var mobilenetPredictions = _mobilenetSession.Run(new List<NamedOnnxValue>
                            {
                                NamedOnnxValue.CreateFromTensor("input", inputTensor)
                            });

                        var mobilenetOutput = mobilenetPredictions.First().AsTensor<float>();

                        var predictedClassIndex = mobilenetOutput.ToArray()
                            .Select((value, index) => new { Value = value, Index = index })
                            .OrderByDescending(x => x.Value)
                            .First().Index;
                        var mobilenetClass = _customLabels[predictedClassIndex];

                        // Draw predictions on the original image
                        DrawPredictions(skBitmap, prediction, mobilenetClass);
                        // Skip feedback for healthy plants
                        if (mobilenetClass != "Healthy" && !feedbackDict.ContainsKey(mobilenetClass))
                        {
                            var feedbackEntry = new FeedbackEntry
                            {
                                Disease = mobilenetClass,
                                Solution = "Feedback pending...",
                                ModelResult = modelResult
                            };
                            modelResult.FeedbackEntries.Add(feedbackEntry);
                            feedbackDict[mobilenetClass] = "Feedback pending...";
                        }
                    }

                    modelResult.ImageUrl = await SaveImage(skBitmap, image.FileName);

                    // Save to database
                    await _unit.ModelRepository.AddAsync(modelResult);

                    BackgroundJob.Enqueue(() => GetFeedbackFromBot(imageId));

                    return modelResult;

                }
            }

        }

        public async Task<ModelResult?> GetFeedback(Guid imageId)
        {

            var modelResult = await _unit.ModelRepository
                .GetAsync(x => x.ImageId == imageId, includeProperties: ["FeedbackEntries"]);
            return modelResult;
        }

        public async Task GetFeedbackFromBot(Guid imageId)
        {
            var modelResult = await _unit.ModelRepository
                .GetAsync(x => x.ImageId == imageId, includeProperties: ["FeedbackEntries"]);

            if (modelResult == null || !modelResult.FeedbackEntries.Any())
            {
                return;
            }

            //var feedbackTasks = new List<Task>();

            foreach (var feedbackEntry in modelResult.FeedbackEntries)
            {
                if (feedbackEntry.Solution == "Feedback pending...")
                {
                    await GetAndUpdateFeedbackAsync(feedbackEntry);
                }
            }

            //await Task.WhenAll(feedbackTasks);
            await _unit.ModelRepository.UpdateAsync(modelResult);

        }


        private async Task GetAndUpdateFeedbackAsync(FeedbackEntry feedbackEntry)
        {
            var feedback = await GetFeedbackFromAI(feedbackEntry.Disease);
            feedbackEntry.Solution = feedback;
        }

        private async Task<string> GetFeedbackFromAI(string disease)
        {

            var prompt = $@"Provide a short, specific, and actionable solution for treating {disease} in plants.Focus only on the most effective treatments and steps to resolve the issue quickly. Avoid unnecessary details.
";
            var response = await _chatService.GetChatResponseAsync(prompt);
            return response;
        }

        private SKBitmap CropImage(SKBitmap bitmap, SKRect rect)
        {
            var croppedBitmap = new SKBitmap((int)rect.Width, (int)rect.Height);
            using (var canvas = new SKCanvas(croppedBitmap))
            {
                canvas.DrawBitmap(bitmap, rect, new SKRect(0, 0, rect.Width, rect.Height));
            }
            return croppedBitmap;
        }

        private Tensor<float> PreprocessImageForMobileNet(SKBitmap bitmap)
        {
            var resizedBitmap = new SKBitmap(224, 224);
            using (var canvas = new SKCanvas(resizedBitmap))
            {
                canvas.DrawBitmap(bitmap, new SKRect(0, 0, 224, 224));
            }

            var inputTensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });
            for (int y = 0; y < 224; y++)
            {
                for (int x = 0; x < 224; x++)
                {
                    var pixel = resizedBitmap.GetPixel(x, y);
                    inputTensor[0, y, x, 0] = pixel.Red / 255.0f;
                    inputTensor[0, y, x, 1] = pixel.Green / 255.0f;
                    inputTensor[0, y, x, 2] = pixel.Blue / 255.0f;
                }
            }

            return inputTensor;
        }

        private void DrawPredictions(SKBitmap bitmap, YoloPrediction prediction, string mobilenetClass)
        {
            using (var canvas = new SKCanvas(bitmap))
            {
                var rect = prediction.Rectangle;
                var label = prediction.Label.Name;
                var confidence = prediction.Score;

                // Draw bounding box
                var boxPaint = new SKPaint
                {
                    Color = SKColors.Red,
                    IsStroke = true,
                    StrokeWidth = 2,
                    Style = SKPaintStyle.Stroke
                };
                canvas.DrawRect(rect, boxPaint);

                // Draw label background
                var text = $"{label} (YOLO) - {confidence:P2}";
                var mobilenetText = $"{mobilenetClass} (MobileNet)";
                var textPaint = new SKPaint
                {
                    Color = SKColors.White,
                    TextSize = 16,
                    IsAntialias = true
                };

                var textBounds = new SKRect();
                textPaint.MeasureText(text, ref textBounds);

                var mobilenetTextBounds = new SKRect();
                textPaint.MeasureText(mobilenetText, ref mobilenetTextBounds);

                var backgroundRect = new SKRect(
                    rect.Left,
                    rect.Top - textBounds.Height - mobilenetTextBounds.Height - 15,
                    rect.Left + Math.Max(textBounds.Width, mobilenetTextBounds.Width) + 10,
                    rect.Top - 5
                );

                var backgroundPaint = new SKPaint
                {
                    Color = SKColors.Black.WithAlpha(128),
                    Style = SKPaintStyle.Fill
                };
                canvas.DrawRect(backgroundRect, backgroundPaint);

                // Draw label text
                canvas.DrawText(text, rect.Left + 5, rect.Top - mobilenetTextBounds.Height - 10, textPaint);
                canvas.DrawText(mobilenetText, rect.Left + 5, rect.Top - 10, textPaint);
            }
        }

        private async Task<string> SaveImage(SKBitmap bitmap, string filename)
        {
            using (var imageStream = new MemoryStream())
            {
                bitmap.Encode(imageStream, SKEncodedImageFormat.Jpeg, 100);
                imageStream.Position = 0;

                string blobName;
                if (filename.Contains("cropguardrover", StringComparison.OrdinalIgnoreCase))
                {
                    blobName = $"rover_{filename}";
                }
                else
                {
                    // Default naming
                    blobName = $"predicted{filename}";
                }
                return await _roverPhotoServices.UploadImageAsync(imageStream, blobName);
            }
        }
    }
}
