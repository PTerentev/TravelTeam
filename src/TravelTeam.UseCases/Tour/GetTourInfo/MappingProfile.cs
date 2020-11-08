using AutoMapper;

namespace TravelTeam.UseCases.Tour.GetTourInfo
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Tour, TourInfoDto>();
        }
    }
}
