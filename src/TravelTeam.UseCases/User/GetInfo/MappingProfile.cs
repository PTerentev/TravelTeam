using AutoMapper;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.User.GetInfo
{
    /// <summary>
    /// Get user info mapping profile.
    /// </summary>
    internal class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
