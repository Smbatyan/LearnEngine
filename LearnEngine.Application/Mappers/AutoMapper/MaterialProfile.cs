using AutoMapper;
using LearnEngine.Application.Commands.Material;
using LearnEngine.Application.Models.Answer;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
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
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            #region ToEntity
            CreateMap<CreateMaterialCommand, MaterialEntity>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Configurations = BsonSerializer.Deserialize<BsonDocument>(JsonSerializer.Serialize<object>(src.Configurations));
                });
            
            CreateMap<AnswerModel, AnswerEntity>();
            CreateMap<AnswerOptionModel, AnswerOptionEntity>();
            #endregion

            #region FromEntity

            CreateMap<MaterialEntity, MaterialResponse>()
                .ForMember(dest => dest.Configurations, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {

                    //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                    //JObject json = JObject.Parse(postBsonDoc.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));

                    //dest.Configurations = BsonTypeMapper.MapToDotNetValue(src.Configurations);
                    dest.Configurations = BsonSerializer.Deserialize<object>(src.Configurations);

                    //dest.Configurations = JsonSerializer.Deserialize<object>(src.Configurations.ToJson());
                })
                ;
            CreateMap<AnswerEntity, AnswerResponse>();
            CreateMap<AnswerOptionEntity, AnswerOptionResponse>();

            #endregion


        }
    }
}
