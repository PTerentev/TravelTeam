using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain;
using Saritasa.Tools.Domain.Exceptions;
using TravelTeam.Domain.Entities;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.User.Register
{
    /// <summary>
    /// Register user command handler.
    /// </summary>
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdResult<string>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IdResult<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<ApplicationUser>(request);
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new ValidationException(ValidationErrors.CreateFromErrors(
                        "An error occurred in user registration!",
                        (string[])result.Errors.Select(e => e.Description)));
            }

            return new IdResult<string>(user.Id);
        }
    }
}
