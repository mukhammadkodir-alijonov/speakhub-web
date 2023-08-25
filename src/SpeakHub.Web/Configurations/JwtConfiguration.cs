﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RegistanFerghanaLC.Web.Configuration;
public static class JwtConfiguration
{
    public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var config = configuration.GetSection("Jwt");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecretKey"]!))
                };
            });
    }
}
