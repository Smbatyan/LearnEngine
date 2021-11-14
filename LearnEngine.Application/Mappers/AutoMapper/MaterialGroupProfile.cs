using AutoMapper;
using LearnEngine.Application.Commands.Material.V1;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace LearnEngine.Application.Mappers.AutoMapper
{
    public class MaterialGroupProfile : Profile
    {
        public MaterialGroupProfile()
        {
            CreateMap<CreateMaterialGroupV1Command, MaterialGroupEntity>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .ForPath(dest => dest.MaterialTypeId, opt => opt.MapFrom(x => (short)x.MaterialTypeId))
                .ForPath(dest => dest.StructureTypeId, opt => opt.MapFrom(x => (short)MaterialStuctureTypes.MaterialGroup))
                .AfterMap((src, dest) =>
                {
                    if (src.Configurations is not null)
                        dest.Configurations = BsonSerializer.Deserialize<BsonDocument>(Newtonsoft.Json.JsonConvert.SerializeObject(src.Configurations));

                    if(src.ChildrenIds.Any())
                    {
                        dest.Children ??= new();

                        foreach (var child in src.ChildrenIds)
                        {
                            dest.Children.Add(ObjectId.Parse(child));
                        }
                    }
                });

            CreateMap<MaterialGroupEntity, MaterialGroupResponse>();

            CreateMap<MaterialGroupEntity, CourseRespons>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.Configurations is not null)
                        dest.Configurations = BsonSerializer.Deserialize<object>(src.Configurations);

                });
        }
    }
}
