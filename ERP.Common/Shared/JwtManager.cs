using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
                        

using ERP.Framework;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ERP.Dtos.Other;

namespace ERP.Common.Shared;

public class JwtManager : IJwtManager
{
    private readonly IOptions<ApplicationOptions> _options;
    public JwtManager(IOptions<ApplicationOptions> options)
    {
        _options = options;
    }

    public string GenerateToken(string sessionUser, int accountId, string name, string family, DateTime expirationDate)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        //var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Value.JwtSecret));

        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new ClaimsIdentity(new[]
        //    {
        //        new Claim(ClaimTypes.Sid, sessionId), new Claim(ClaimTypes.NameIdentifier, accountId.ToString()), new Claim(ClaimTypes.Name, $"{name} {family}")
        //    }),
        //    Claims = new Dictionary<string, object>()
        //    {
        //        {
        //            CustomClaims.AccountId, accountId
        //        }
        //    },

        //    Expires = expirationDate,
        //    SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature),
        //    Issuer = _options.Value.JwtIssuer,
        //    Audience = _options.Value.JwtAudience,

        //};


        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sid, sessionUser),
                        new Claim(JwtRegisteredClaimNames.Sub, _options.Value.JwtSubject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", accountId.ToString()),
                        new Claim("DisplayName", name + " " + family), 
                    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.JwtKey));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _options.Value.JwtIssuer,
            _options.Value.JwtAudience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

    
        return tokenHandler.WriteToken(token);
    }
}
