using MachiKoro.Api.Extensions;
using MachiKoro.Api.Options;
using MachiKoro.Application.v1.Extensions;
using MachiKoro.Infrastructure.Identity;
using MachiKoro.Infrastructure.Identity.Models.Authentication;
using MachiKoro.Persistence.Extensions;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MachiKoro.Api
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
            //services.InstallServicesInAssembly(Configuration);

            // Strongly-typed configurations using IOptions
            services.Configure<Token>(Configuration.GetSection("token"));
            services.Configure<TokenServiceProvider>(Configuration.GetSection("TokenServiceProvider"));

            //services.SetupAuthentication(Configuration);
            //services.SetAuthorization();

            services.AddPersistenceServices(Configuration);
            services.AddMediatRServices(Configuration);
            services.AddAutoMapperServices(Configuration);
            services.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
            services.AddApplicationServices(Configuration);
            services.AddPersistenceServices(Configuration);
            services.AddAuthenticationServices(Configuration);
            services.AddAuthorizationServices(Configuration);

            services.AddSwaggerServices(Configuration);

            services.AddCors();
            services.AddControllers();
        }  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                app.SeedIdentityDataAsync().Wait();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
