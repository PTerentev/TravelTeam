using MediatR;

namespace TravelTeam.UseCases.Tour.ParticipateInTour
{
    public class ParticipateInTourCommand : IRequest
    {
        public string UserId { get; set; }

        public int TourId { get; set; }
    }
}
