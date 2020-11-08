using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelTeam.Abstractions.Infrastructure;
using TravelTeam.Domain.Options;

namespace TravelTeam.Infrastructure.Authentication
{
    /// <summary>
    /// JWT access token generation service.
    /// </summary>
    public class JwtAccessTokenGenerationService : IAccessTokenGenerationService
    {
        private readonly JwtOptions jwtOptions;

        /// <summary>
        /// Constructor.
        /// </summary>
        public JwtAccessTokenGenerationService(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }

        /// <inheritdoc/>
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(jwtOptions.ExpirationTimeSeconds),
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                signingCredentials:
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey)), 
                        SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        /// <inheritdoc/>
        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(
                token, 
                new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey)),
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateLifetime = false
                }, 
                out SecurityToken _);
            return principal.Claims;
        }
    }
}
