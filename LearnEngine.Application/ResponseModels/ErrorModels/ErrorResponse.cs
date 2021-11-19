using System.Text.Json.Serialization;

namespace LearnEngine.Application.ResponseModels.ErrorModels
{
    public class ErrorResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Data { get; set; }
    }
}
