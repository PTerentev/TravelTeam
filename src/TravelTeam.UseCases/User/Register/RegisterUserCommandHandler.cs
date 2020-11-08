using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.User.Register
{
    /// <summary>
    /// Register user command handler.
    /// </summary>
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
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
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<ApplicationUser>(request);
            await userManager.CreateAsync(user, request.Password);

            return Unit.Value;
        }
    }
}
