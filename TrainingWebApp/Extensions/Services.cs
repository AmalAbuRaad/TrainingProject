using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.IRepo;
using TrainingWebApp.Repo;

namespace TrainingWebApp.Extensions
{
    public static class Services
    {
        public static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPostRepo, PostRepo>();
            return services;
        }


    }
}
