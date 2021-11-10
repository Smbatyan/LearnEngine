using LearnEngine.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearnEngine.Application.ResponseModels
{
    public class MaterialGroupResponse
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
        /// The type id of material for example 1 - Material, 2 - MaterialGroup
        /// </summary>
        [EnumDataType(typeof(MaterialStuctureTypes))]
        public MaterialStuctureTypes StuctureTypeId { get; set; }

        /// <summary>
        /// Configurations in json format
        /// </summary>
        public object Configurations { get; set; }

        /// <summary>
        /// List of children id
        /// </summary>
        public List<string> Children { get; set; }
    }
}
