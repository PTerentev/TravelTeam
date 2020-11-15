using MediatR;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.User.GetInfo
{
    /// <summary>
    /// Get user info query.
    /// </summary>
    public class GetUserInfoQuery : IRequest<UserDto>
    {
        public string UserId { get; set; }
    }
}
