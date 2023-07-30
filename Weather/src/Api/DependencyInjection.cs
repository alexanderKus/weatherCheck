using System;
namespace Api
{
	public static class DependencyInjection
	{
        private static string MyAllowSpecificOrigins = "_allowAllOrigins";

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
		{
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                                  });
            });
            return services;
		}
	}
}

