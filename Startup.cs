using ChatEkoSystem.Business;
using ChatEkoSystem.Data;
using ChatEkoSystem.Data.UnitOfWork;
using ChatEkoSystem.Hubs;
using ChatEkoSystem.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace ChatEkoSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var sqlConnectionString = Configuration["PostgreSqlConnectionString"];

            services.AddDbContext<Context>(options => options.UseNpgsql(sqlConnectionString));
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddCors(options => options.AddDefaultPolicy(policy => policy
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .SetIsOriginAllowed(origin => true)));      
            services.AddTransient<MyBusiness>();
            services.AddSignalR();
            services.AddControllers();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHub>("/myhub");
                endpoints.MapHub<MessageHub>("/messagehub");
                endpoints.MapControllers();
            });
        }
    }
}
