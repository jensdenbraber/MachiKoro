using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachiKoro.Application.v1.Extensions
{
	[ExcludeFromCodeCoverage]
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
			//services.AddPersistence(configuration);
			//services.AddScenarioWonenServices(configuration);
			//services.AddCalculationServices(configuration);
			//services.AddReportDataConvertersExtensions(configuration);

			return services;
		}

		public static IServiceCollection AddReportDataConvertersExtensions(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddScoped<IDataConverter, DossierDataConverter>();
			//services.AddScoped<IDataConverter, CreateReportRequestDataConverter>();
			//services.AddScoped<IDataConverter, SituatieDataConverter>();
			//services.AddScoped<IDataConverter, SurveyDataConverter>();

			return services;
		}
	}
}
