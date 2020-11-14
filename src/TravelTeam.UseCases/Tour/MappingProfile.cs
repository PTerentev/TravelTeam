using AutoMapper;

namespace TravelTeam.UseCases.Tour
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Tour, TourInfoDto>();
        }
    }
}
