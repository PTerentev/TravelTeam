using AutoMapper;

namespace TravelTeam.UseCases.Tour.CreateTour
{
    /// <summary>
    /// Create tour mapping profile.
    /// </summary>
    internal class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<CreateTourCommand, Domain.Entities.Tour>();
        }
    }
}
