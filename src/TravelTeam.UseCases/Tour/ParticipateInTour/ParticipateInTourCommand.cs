using MediatR;

namespace TravelTeam.UseCases.Tour.ParticipateInTour
{
    /// <summary>
    /// Participate in tour command.
    /// </summary>
    public class ParticipateInTourCommand : IRequest
    {
        /// <summary>
        /// User ID.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Tour ID.
        /// </summary>
        public int TourId { get; set; }
    }
}
