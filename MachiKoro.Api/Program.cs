using MachiKoro.Api.Extensions;
using MachiKoro.Api.Hubs;
using MachiKoro.Application.v1.Extensions;
using MachiKoro.Domain.Interfaces;
using MachiKoro.Persistence.Extensions;
using MachiKoro.Persistence.Identity;
using MachiKoro.Persistence.Identity.Models.Authentication;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MachiKoro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder(args);

            // Strongly-typed configurations using IOptions
            builder.Services.Configure<Token>(builder.Configuration.GetSection("token"));
            builder.Services.Configure<TokenServiceProvider>(builder.Configuration.GetSection("TokenServiceProvider"));

            //services.SetupAuthentication(Configuration);
            //services.SetAuthorization();

            //builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddMediatRServices(builder.Configuration);
            builder.Services.AddAutoMapperServices(builder.Configuration);
            builder.Services.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddAuthenticationServices(builder.Configuration);
            builder.Services.AddAuthorizationServices(builder.Configuration);

            builder.Services.AddSwaggerServices(builder.Configuration);

            builder.Services.AddFluentValidationServices(builder.Configuration);

            builder.Services.AddTransient<INotifyPlayerService, GameHubContext>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000")
                        .AllowCredentials();
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}