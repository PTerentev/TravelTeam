using MediatR;
using System.Collections.Generic;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.GetToursByUser
{
    /// <summary>
    /// Get tours by user query.
    /// </summary>
    public class GetToursByUserQuery : IRequest<IEnumerable<TourDto>>
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public string UserId { get; set; }
    }
}
