using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachiKoro.Application.v1.Extensions
{
    [ExcludeFromCodeCoverage]
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{

			return services;
		}
	}
}
