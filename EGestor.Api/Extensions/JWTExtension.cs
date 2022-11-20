using EGestor.Shared.Services;
using EGestor.Domain.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EGestor.Api.Extensions;

public static class JWTExtension
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJwtService, JwtService>();

        var chave = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value!);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(chave),
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
                ValidateAudience = true,
                ValidAudience = configuration.GetSection("JWT:Audience").Value,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void UseJwtConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
