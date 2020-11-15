using AutoMapper;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.User.Register
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserCommand, ApplicationUser>()
                .ForSourceMember(r => r.Password, opt => opt.DoNotValidate());
        }
    }
}
