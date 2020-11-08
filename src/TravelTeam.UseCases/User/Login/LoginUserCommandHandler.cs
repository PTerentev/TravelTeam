using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using TravelTeam.Abstractions.Infrastructure;
using TravelTeam.Domain.Entities;
using TravelTeam.Infrastructure.Authentication;

namespace TravelTeam.UseCases.User.Login
{
    /// <summary>
    /// Login user command handler.
    /// </summary>
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResult>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccessTokenGenerationService accessTokenGenerationService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public LoginUserCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IAccessTokenGenerationService accessTokenGenerationService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.accessTokenGenerationService = accessTokenGenerationService;
        }

        /// <inheritdoc/>
        public async Task<LoginUserCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            if (!result.Succeeded)
            {
                if (result.IsNotAllowed)
                {
                    throw new DomainException($"User is not allowed to Sign In.");
                }
                if (result.IsLockedOut)
                {
                    throw new DomainException($"User {request.Email} is locked out.");
                }
                throw new DomainException("Email or password is incorrect.");
            }

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new DomainException($"User with email {request.Email} not found.");
            }

            var principal = await signInManager.CreateUserPrincipalAsync(user);
            return new LoginUserCommandResult
            {
                UserId = user.Id,
                Token = Generate(principal.Claims)
            };
        }

        private string Generate(IEnumerable<Claim> claims)
        {
            var iatClaim = new Claim(
                AuthenticationConstants.IatClaimType,
                DateTime.UtcNow.Ticks.ToString(),
                ClaimValueTypes.Integer64);

            return accessTokenGenerationService.GenerateToken(claims.Union(new[] { iatClaim }));
        }
    }
}
