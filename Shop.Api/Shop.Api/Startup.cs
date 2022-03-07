using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Api.Infrastructure;
using Shop.Api.Services;
using Shop.Api.Services.Logs;

namespace Shop.Api
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

            string connection = Configuration.GetConnectionString("Connection");

            services.AddDbContext<ShopContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(connection);
            });

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddScoped<ILogWriterFactory, LogWriterFactory>();



            MapperConfiguration mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MapProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            services.AddControllers();

            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(Configuration.GetSection("WebHosts").Get<string[]>()));

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
