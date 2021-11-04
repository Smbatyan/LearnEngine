using LearnEngine.Infrastucture.Settings.MongoSettings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;

namespace LearnEngine.API.Ioc
{
    public static class ConfigurationProvider
    {
        public static void AddMongoConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}
