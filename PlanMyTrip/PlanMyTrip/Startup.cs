using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanMyTrip.Data;
using PlanMyTrip.Services;
using Refit;

namespace PlanMyTrip
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
            services.AddControllersWithViews();
            services.AddDbContext<TripContext>();
            services.AddScoped<ITripRepository, TripRepository>();

            // Refit 
            var settings = new RefitSettings();

            services.AddRefitClient<IGooglePlaceApi>(settings)
                .ConfigureHttpClient(client => {
                    client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place");
                    client.Timeout = TimeSpan.FromSeconds(15);
                });

            services.AddRefitClient<IGoogleDistanceMatrixApi>(settings)
                .ConfigureHttpClient(client => {
                    client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/distancematrix");
                    client.Timeout = TimeSpan.FromSeconds(15);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");
            });
        }
    }
}
