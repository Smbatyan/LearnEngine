using LearnEngine.Infrastucture.Settings.MongoSettings;
using Microsoft.Extensions.Options;

namespace LearnEngine.API.Ioc
{
    public static class ConfigurationProvider
    {
        public static void AddMongoConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}
