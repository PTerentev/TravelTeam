using System.ComponentModel.DataAnnotations;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.GetTours
{
    /// <summary>
    /// Get tours query.
    /// </summary>
    public class GetToursQuery : IRequest<PagedListMetadataDto<TourShortDto>>
    {
        /// <summary>
        /// Page number.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Page size.
        /// </summary>
        public int PageSize { get; set; } = 1000;
    }
}
