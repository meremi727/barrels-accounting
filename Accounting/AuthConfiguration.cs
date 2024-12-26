using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BarrelsAccounting.Accounting;

/// <summary>
/// Применяет настройки аутентификации через keycloak из конфигурационного файла.
/// </summary>
public static class AuthConfiguration
{
    /// <summary>
    /// Добавляет аутентификацию через Keycloak.
    /// </summary>
    /// <param name="builder">  </param>
    /// <exception cref="KeyNotFoundException"> Неполный файл конфигурации. </exception>
    public static void AddKeycloak(this WebApplicationBuilder builder)
    {
        string getAuthItem(string name) 
            => builder.Configuration[$"Authentication:{name}"] 
                ?? throw new KeyNotFoundException($"Элемента Authentication:{name} нет в файле конфигурации.");

        SymmetricSecurityKey getSymKey(string val) 
            => new(Encoding.UTF8.GetBytes(val));

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    ValidIssuer = getAuthItem("issuer"),
                    ValidAudience = getAuthItem("audience"),
                    IssuerSigningKey = getSymKey(getAuthItem("key"))
                };
            });
    }
}