using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.ResponseModels
{
    public class TreeResponse
    {
        public string MaterialId { get; set; }

        // public BaseMaterialResponse Material { get; set; }

        public object Configurations { get; set; }

        //public List<TreeResponse> Children { get; set; }
    }
}
