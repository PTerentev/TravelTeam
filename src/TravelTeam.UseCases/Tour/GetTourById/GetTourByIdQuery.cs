using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TravelTeam.UseCases.Tour.GetTourById
{
    public class GetTourByIdQuery : IRequest<TourInfoDto>
    {
        [Required]
        public int? TourId { get; set; }
    }
}
