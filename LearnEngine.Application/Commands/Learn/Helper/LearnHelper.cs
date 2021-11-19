using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Learn;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Entities.SQL;
using LearnEngine.Core.Enums;
using MongoDB.Bson;
//using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Learn.Helper
{
    public class LearnHelper : ILearnHelper
    {
        Dictionary<string, MaterialEntity> materials;
        Dictionary<string, MaterialGroupEntity> materialGroups;

        public List<CompactMaterial> GetNodeIdsAndTypes(Node node)
        {
            List<CompactMaterial> response = new();

            scan(new List<Node>() { node });

            List<Node> scan(List<Node> list)
            {
                int z = 0;
                List<Node> lists = new List<Node>();

                if (list.Count > 0)
                {
                    lists.AddRange(list);
                }

                foreach (Node x in list)
                {
                    response.Add(new CompactMaterial() { Id = x.Id, TypeId = (MaterialTypes)x.MaterialTypeId, StructureTypeId = (MaterialStuctureTypes)x.StructureTypeId }); // TODO

                    Node dbNode = x;
                    if (dbNode.SubNodes == null)
                    {
                        z++;
                        continue;
                    }

                    List<Node> sub = dbNode.SubNodes.ToList();
                    dbNode.SubNodes = scan(sub);
                    lists[z] = dbNode;
                    z++;
                }

                return lists;
            }

            return response;
        }

        public CourseStuctureEntity MergeData(
            Node node,
            Dictionary<string, MaterialEntity> materials,
            Dictionary<string, MaterialGroupEntity> materialGroups)
        {
            this.materials = materials;
            this.materialGroups = materialGroups;

            CourseStuctureEntity course = new()
            {
                MaterialId = node.Id,
                Material = materialGroups[node.Id],
                Children = MergeRecursive(node.SubNodes)
            };

            return course;
        }

        private List<CourseStuctureEntity> MergeRecursive(List<Node> node)
        {
            List<CourseStuctureEntity> courses = new();

            foreach (var item in node)
            {
                CourseStuctureEntity course = new()
                {
                    MaterialId = item.Id,
                    Material = materialGroups.ContainsKey(item.Id) ? materialGroups[item.Id] : materials.ContainsKey(item.Id) ? materials[item.Id] : null,
                    Children = MergeRecursive(item.SubNodes)
                };

                courses.Add(course);
            }

            return courses;
        }

        public Node GenerateNodeStructure(List<Relation> relations)
        {
            Node node = FillRecursive(relations).FirstOrDefault();

            return node;
        }

        private List<Node> FillRecursive(List<Relation> flatObjects, string parentId = null)
        {
            var nodes = flatObjects
                .Where(x => x.ParentId == parentId)
                .Select(item => new Node
                {
                    Id = item.MaterialId,
                    ParentId = item.ParentId,
                    MaterialTypeId = item.MaterialTypeId,
                    StructureTypeId = item.StructureTypeId,
                    SubNodes = FillRecursive(flatObjects, item.MaterialId)
                }).ToList();

            return nodes;
        }
    }
}