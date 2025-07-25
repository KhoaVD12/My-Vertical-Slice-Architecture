﻿using Lab3_Presentation.Authentication.SignIn;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab3_Presentation.Middleware;

public class JWT
{
    private readonly IConfiguration _configuration;

    public JWT(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string email, string role)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];

        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
