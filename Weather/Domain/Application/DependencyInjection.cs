using System.Reflection;
using Application.Behaviors;
using Application.Commands;
using Domain.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).GetTypeInfo().Assembly));
			services.AddScoped<IPipelineBehavior<Coordinates, WeatherStatistics>, ValidateCoordinateBehavior>();
			services.AddScoped<IValidator<Coordinates>, CoordinatesValidator>();
			return services;
		}
	}
}

