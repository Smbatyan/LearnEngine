using LearnEngine.Core.Repositories;
using LearnEngine.Core.Repositories.MSSQL;
using LearnEngine.Infrastucture.Repositories;
using LearnEngine.Infrastucture.Repositories.MSSQL;

namespace LearnEngine.API.Installers
{
    public static class InstallRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMaterialRespository<>), typeof(MaterialRespository<>));
            services.AddScoped(typeof(IUserCourseRepository<>), typeof(UserCourseRepository<>));
            services.AddScoped(typeof(IMaterilRelationRepository), typeof(MaterilRelationRepository));
        }
    }
}