using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowRank.Domain.EF;
using ShowRank.Domain.EF.IRepositories;
using ShowRank.Domain.EF.Repositories;
using ShowRank.Services.Implementations;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.WebApi
{
    public static class ServicesExtensionMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["ConnectionStrings:DefaultString"];
            services.AddDbContext<ShowRankDbContext>(c => c.UseSqlServer(connectionString, b => b.MigrationsAssembly("ShowRank.WebApi")));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IFollowsTableRepository, FollowsTableRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IToSeeListItemRepository, ToSeeListItemRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IFollowsTableServices, FollowsTableServices>();
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<IProfileServices, ProfileServices>();
            services.AddScoped<IToSeeListItemServices, ToSeeListItemServices>();
        }
    }
}
