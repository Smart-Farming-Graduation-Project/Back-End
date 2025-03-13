using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Croppilot.Core.Bases
{
    public class HttpStatusCodeConverter : JsonConverter<HttpStatusCode>
    {
        public override HttpStatusCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // Convert string like "BadRequest" to HttpStatusCode
                if (Enum.TryParse<HttpStatusCode>(reader.GetString(), true, out var statusCode))
                {
                    return statusCode;
                }
                throw new JsonException($"Invalid HTTP status code string: {reader.GetString()}");
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                // Convert integer like 400 to HttpStatusCode
                return (HttpStatusCode)reader.GetInt32();
            }

            throw new JsonException("Invalid JSON token for HttpStatusCode");
        }

        public override void Write(Utf8JsonWriter writer, HttpStatusCode value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}