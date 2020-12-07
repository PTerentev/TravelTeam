using AutoMapper;
using System.Linq;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.Common
{
    /// <summary>
    /// Common mapping profile.
    /// </summary>
    internal class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();

            CreateMap<Domain.Entities.Tour, TourDto>()
                .ForMember(
                dto => dto.TourParticipants,
                opt => opt.MapFrom(tour => tour.TourParticipants.Select(part => part.User))).IncludeMembers();
        }
    }
}
