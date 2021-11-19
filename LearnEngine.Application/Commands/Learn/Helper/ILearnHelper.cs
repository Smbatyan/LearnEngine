using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Learn;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Entities.SQL;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Learn.Helper
{
    public interface ILearnHelper
    {
        List<CompactMaterial> GetNodeIdsAndTypes(Node node);
        
        CourseStuctureEntity MergeData(Node node, Dictionary<string, MaterialEntity> materials, Dictionary<string, MaterialGroupEntity> materialGroupss);

        Node GenerateNodeStructure(List<Relation> relations);
    }
}
