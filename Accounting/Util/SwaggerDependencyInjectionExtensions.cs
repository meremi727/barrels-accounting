using Microsoft.OpenApi.Models;

namespace BarrelsAccounting.Accounting.Util;

/// <summary>
/// Определяет расширения для подключения Swagger.
/// </summary>
public static class SwaggerDIExtensions
{
	/// <summary>
	/// Добавляет Swagger и аутентификацию к нему.
	/// </summary>
	/// <param name="services"> Экземпляр <see cref="IServiceCollection" />. </param>
	/// <exception cref="ArgumentNullException"> Если один из аргументов не задан. </exception>
	public static void AddSwagger(this IServiceCollection services)
	{
		ArgumentNullException.ThrowIfNull(services, nameof(services));

		services.AddSwaggerGen(c =>
		{
			const string authScheme = "Bearer";
			var securitySchema = new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = authScheme,
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = authScheme
				}
			};

			c.AddSecurityDefinition(authScheme, securitySchema);
			c.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{ securitySchema, new[] { authScheme } }
			});
		});
	}
}