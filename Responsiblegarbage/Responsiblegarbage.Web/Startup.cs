using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Responsiblegarbage.Models;
using Responsiblegarbage.Shared;
using Responsiblegarbage.Web.Data;
using Responsiblegarbage.Web.Models;
using Responsiblegarbage.Web.Services;

namespace Responsiblegarbage.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
               options.UseNpgsql(
                   Configuration.GetConnectionString("DefaultConnection"),
                   o => o.UseNetTopologySuite()));

            services.AddControllers();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDumpsterService, DumpsterService>();


            TypeAdapterConfig<Dumpster, DumpsterDto>.NewConfig()
                     .Map(dest => dest.Location, src => new Location(src.Location.X, src.Location.Y));
                     //.Map(dest => dest.Types, src => src.Types);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}