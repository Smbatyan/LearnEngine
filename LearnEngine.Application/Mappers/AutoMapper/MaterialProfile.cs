using AutoMapper;
using LearnEngine.Application.Commands.Material;
using LearnEngine.Application.Models.Answer;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities.Answer;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace LearnEngine.Application.Mappers.AutoMapper
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            #region ToEntity
            CreateMap<CreateMaterialCommand, MaterialEntity>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .ForPath(dest => dest.MaterialTypeId, opt => opt.MapFrom(x => (short)x.MaterialTypeId))
                .ForPath(dest => dest.StructureTypeId, opt => opt.MapFrom(x => (short)MaterialStuctureTypes.Material))
                .AfterMap((src, dest) =>
                {
                    if (src.Configurations is not null)
                        dest.Configurations = BsonSerializer.Deserialize<BsonDocument>(JsonSerializer.Serialize(src.Configurations));                    
                });

            CreateMap<AnswerModel, AnswerEntity>();
            CreateMap<AnswerOptionModel, AnswerOptionEntity>();

            #endregion

            #region FromEntity

            CreateMap<MaterialEntity, MaterialResponse>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                //.ForMember(dest => dest.Children, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.Configurations is not null)
                        dest.Configurations = BsonSerializer.Deserialize<object>(src.Configurations);
                    
                });

            CreateMap<AnswerEntity, AnswerResponse>();
            CreateMap<AnswerOptionEntity, AnswerOptionResponse>();

            #endregion


        }
    }
}
