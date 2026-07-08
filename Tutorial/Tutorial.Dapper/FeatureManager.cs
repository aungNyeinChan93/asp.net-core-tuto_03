using Dapper.Database.Database.AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Tutorial.Dapper.Services.DapperService;

namespace Tutorial.Dapper
{
    public static class FeatureManager
    {
        public static WebApplicationBuilder MapFeatureManager(this WebApplicationBuilder builder)
        {
            builder
                .AddDatabase()
                .AddDapperService();

            return builder;
        }

        public static WebApplicationBuilder AddDapperService(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IDapperService, DapperService>();

            return builder;
        }


        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            return builder;
        }
    }
}
