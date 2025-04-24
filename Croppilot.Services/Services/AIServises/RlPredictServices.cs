using Croppilot.Date.Helpers;
using Croppilot.Services.Abstract.AiSerives;
using Croppilot.Services.Abstract.DashboredServices;
using Microsoft.Extensions.Configuration;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Croppilot.Services.Services.AIServises
{
    public class RlPredictServices : IRlPredictServices
    {
        private readonly IConfiguration _configuration;
        private readonly IWeatherServices _weatherServices;
        private readonly InferenceSession _session;
        private const float MaxFertilizer = 50.0f;


        public RlPredictServices(IConfiguration configuration, IWeatherServices weatherServices)
        {
            _configuration = configuration;
            _weatherServices = weatherServices;
            var modelPath = Path.Combine(_configuration["AiModels:RLModelPath"]
                                         ?? throw new InvalidOperationException("RL Model Path configuration is missing"));
            _session = new InferenceSession(modelPath);
            //VerifyModelSignature();
        }

        public async Task<int> PredictAction(SmartFarmObservation observation)
        {
            if (observation == null)
            {
                throw new ArgumentNullException(nameof(observation));
            }
            float normalizedFertilizer = observation.FertilizerLevel / MaxFertilizer;
            var inputTensor = PrepareInputTensor(observation, normalizedFertilizer);
            // Verify tensor shape before running
            if (inputTensor.Dimensions[0] != 1 || inputTensor.Dimensions[1] != 6)
            {
                throw new InvalidOperationException($"Input tensor has invalid shape:");
            }
            using var results = _session.Run(new[]
            {
                    NamedOnnxValue.CreateFromTensor("input", inputTensor)
            });
            var outputTensor = results.First().AsTensor<long>();
            int action = (int)outputTensor[0];
            return action;

        }

        public async Task<SmartFarmObservation> GetDefaultValue()
        {
            var weather = await _weatherServices.GetCurrentTempAndHim();
            double sunlight = weather.Condition.ToLower() switch
            {
                "clear" => 1.0,
                "clouds" => 0.5,
                "rain" => 0.2,
                "snow" => 0.3,
                "mist" or "fog" => 0.2,
                "thunderstorm" => 0.1,
                _ => 0.4
            };
            var result = new SmartFarmObservation
            {
                Temperature = weather.Temperature,
                Humidity = weather.Humidity,
                SoilMoisture = Math.Round(.3f, 2),
                Growth = 0.5f,
                FertilizerLevel = 20, // default safe level
                Sunlight = sunlight
            };
            return result;
        }
        private static DenseTensor<float> PrepareInputTensor(SmartFarmObservation observation,
            float normalizedFertilizer)
        {
            float[] input =
            [
                (float)observation.Temperature,
                (float)observation.Humidity,
                (float)observation.SoilMoisture,
                (float)observation.Growth,
                normalizedFertilizer,
                (float)observation.Sunlight
            ];

            return new DenseTensor<float>(input, [1, 6]);
        }

    }
}