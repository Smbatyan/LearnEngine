using System.Text.Json.Serialization;

namespace LearnEngine.Application.ResponseModels
{
    /// <summary>
    /// The Material class.
    /// </summary>
    public record MaterialResponse
    {
        /// <summary>
        /// Material Metadata
        /// </summary>
        public MaterialMetadataResponse Metadata { get; set; }

        /// <summary>
        /// Configurations in json format
        /// </summary>
        public object Configurations { get; set; }

        /// <summary>
        /// Children Materials
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<MaterialResponse> Materials { get; set; }
    }
}