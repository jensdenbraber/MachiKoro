using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace MachiKoro.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class SwaggerServicesExtensions
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Machi Koro API",
                Description = "An API implementation of the Machi Koro cardgame.",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Jens den Braber",
                    Email = "jens.denbraber@gmail.com",
                    Url = new Uri("https://github.com/jensdenbraber/MachiKoro/"),
                },
                License = new OpenApiLicense
                {
                    Name = "License information comes here",
                    Url = new Uri("https://example.com/license"),
                }
            });
            x.AddSignalRSwaggerGen();
            x.ExampleFilters();

            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = JwtBearerDefaults.AuthenticationScheme.ToLowerInvariant()
            });
            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {new OpenApiSecurityScheme{Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }}, new List<string>()}
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            x.IncludeXmlComments(xmlPath);
        });

        services.AddSwaggerExamplesFromAssemblyOf<Program>();

        return services;
    }
}