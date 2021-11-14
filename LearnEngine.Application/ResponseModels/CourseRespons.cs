using LearnEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.ResponseModels
{
    public class CourseRespons
    {
        /// <summary>
        /// Unique identifier of material
        /// </summary>
        public string MaterialGroupId { get; set; }

        /// <summary>
        /// Name of material
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrition of material
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Configurations of material
        /// </summary>
        public object Configurations { get; set; }
    }
}
