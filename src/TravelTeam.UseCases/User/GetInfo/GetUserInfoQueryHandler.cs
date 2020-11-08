using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.User.GetInfo
{
    /// <summary>
    /// Get user info query handler.
    /// </summary>
    internal class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDto>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetUserInfoQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var applicationUser = await userManager.FindByIdAsync(request.UserId);
            var userDto = mapper.Map<UserDto>(applicationUser);

            return userDto;
        }
    }
}
