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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MachiKoro.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Strongly-typed configurations using IOptions
        builder.Services.Configure<Token>(builder.Configuration.GetSection("token"));
        builder.Services.Configure<TokenServiceProvider>(builder.Configuration.GetSection("TokenServiceProvider"));

        builder.Services.AddMediatRServices(builder.Configuration);
        builder.Services.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddAuthenticationServices(builder.Configuration);
        builder.Services.AddAuthorizationServices(builder.Configuration);
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
        builder.Services.AddSwaggerServices(builder.Configuration);
        builder.Services.AddLogging();

        var app = builder.Build();

        app.UseCors("ClientPermission");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");//.RequireCors("ClientPermission");
            endpoints.MapHub<GameHub>("/hubs/GameHub");//.RequireCors("ClientPermission");
            endpoints.MapHub<GameHub>("/hubs/GameLobbyHub");//.RequireCors("ClientPermission");
                                                            //endpoints.MapHub<SignalRNotificationHub>("/hubs/SignalRNotification");
        });

        //app.MapControllers();

        app.Run();
    }
}