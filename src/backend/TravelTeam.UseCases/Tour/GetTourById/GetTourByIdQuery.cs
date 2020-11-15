using System.ComponentModel.DataAnnotations;
using MediatR;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.GetTourById
{
    /// <summary>
    /// Get tour by ID query.
    /// </summary>
    public class GetTourByIdQuery : IRequest<TourDto>
    {
        /// <summary>
        /// Tour ID.
        /// </summary>
        [Required]
        public int? TourId { get; set; }
    }
}
