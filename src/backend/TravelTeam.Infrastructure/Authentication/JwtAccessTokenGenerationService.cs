using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly JwtOptions options;

        /// <summary>
        /// Constructor.
        /// </summary>
        public JwtAccessTokenGenerationService(IOptionsMonitor<JwtBearerOptions> jwtOptionsMonitor, IOptions<JwtOptions> options)
        {
            this.options = options.Value;

            this.tokenValidationParameters = jwtOptionsMonitor.Get(JwtBearerDefaults.AuthenticationScheme)
                .TokenValidationParameters.Clone();
            // For this we don't need to validate lifetime because we don't use validation here at all.
            this.tokenValidationParameters.ValidateLifetime = false;
        }


        /// <inheritdoc/>
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtSecurityToken = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.UtcNow.AddSeconds(options.ExpirationTimeSeconds),
               issuer: tokenValidationParameters.ValidIssuer,
               audience: tokenValidationParameters.ValidAudience,
               signingCredentials:
                   new SigningCredentials(tokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        /// <inheritdoc/>
        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(
                token, 
                tokenValidationParameters, 
                out SecurityToken _);
            return principal.Claims;
        }
    }
}
