using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Accounting;

/// <summary>
/// Применяет настройки авторизации через keycloak из конфигурационного файла.
/// </summary>
public static class AuthConfiguration
{
    public static void AddKeycloak(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.Audience = "broker";
             options.ClaimsIssuer = "http://localhost:8080/realms/BarrelsAccounting";
             options.RequireHttpsMetadata = false;
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 ValidIssuer = "http://localhost:8080/realms/BarrelsAccounting",
                 ValidAudience = "broker",
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pRwQ9eZuY8u8QIsrEEK1hz9TtDQUAcGB"))
             };
         });

         builder.Services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
    }
}