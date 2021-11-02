using LearnEngine.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LearnEngine.Application.ResponseModels
{
    public record MaterialMetadataResponse
    {
        /// <summary>
        /// Unique identifier of material
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of material
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type id of material for example 1 - Text, 2 - Question, 3 - CC etc. 
        /// </summary>
        [EnumDataType(typeof(MaterialTypes))]
        public MaterialTypes MaterialTypeId { get; set; }

        /// <summary>
        /// The type id of material meta for example 1 - Material, 2 - MaterialGroup
        /// </summary>
        [EnumDataType(typeof(MaterialMetaTypes))]
        public MaterialMetaTypes MetaTypeId { get; set; }

        /// <summary>
        /// Markup of body 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Body { get; set; }

        /// <summary>
        /// Configurations in json format
        /// </summary>
        public object Configurations { get; set; }

        /// <summary>
        /// Answers of question
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AnswerResponse Answer { get; set; }
    }
}