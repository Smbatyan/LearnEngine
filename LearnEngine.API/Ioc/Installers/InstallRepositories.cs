using LearnEngine.Core.Repositories;
using LearnEngine.Infrastucture.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.API.Installers
{
    public static class InstallRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMaterialRespository, MaterialRespository>();
        }
    }
}
