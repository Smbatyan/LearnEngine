using AutoMapper;
using LearnEngine.Application.Commands.Material;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearnEngine.Application.Mappers.AutoMapper
{
    public class MaterialGroupProfile : Profile
    {
        public MaterialGroupProfile()
        {
            CreateMap<CreateMaterialGroupCommand, MaterialGroupEntity>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .ForPath(dest => dest.MaterialTypeId, opt => opt.MapFrom(x => (short)x.MaterialTypeId))
                .ForPath(dest => dest.StructureTypeId, opt => opt.MapFrom(x => (short)MaterialStuctureTypes.MaterialGroup))
                .AfterMap((src, dest) =>
                {
                    if (src.Configurations is not null)
                        dest.Configurations = BsonSerializer.Deserialize<BsonDocument>(JsonSerializer.Serialize(src.Configurations));
                });
        }
    }
}
