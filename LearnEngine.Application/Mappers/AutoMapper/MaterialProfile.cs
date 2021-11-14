using AutoMapper;
using LearnEngine.Application.Commands.Material.V1;
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
            CreateMap<CreateMaterialV1Command, MaterialEntity>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .ForPath(dest => dest.MaterialTypeId, opt => opt.MapFrom(x => (short)x.MaterialTypeId))
                .ForPath(dest => dest.StructureTypeId, opt => opt.MapFrom(x => (short)MaterialStuctureTypes.Material))
                .AfterMap((src, dest) =>
                {
                    if (src.Configurations is not null)
                        dest.Configurations = BsonSerializer.Deserialize<BsonDocument>(Newtonsoft.Json.JsonConvert.SerializeObject(src.Configurations));                    
                });

            CreateMap<AnswerModel, AnswerEntity>()
                .ForMember(dest => dest.RightAnswerHash, opt => opt.MapFrom(x => x.RightAnswer));

            CreateMap<AnswerOptionModel, AnswerOptionEntity>();

            #endregion

            #region FromEntity

            CreateMap<MaterialEntity, MaterialResponse>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .ForMember(dest => dest.StuctureTypeId, opt => opt.MapFrom(x=> (MaterialStuctureTypes)x.StructureTypeId))
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
