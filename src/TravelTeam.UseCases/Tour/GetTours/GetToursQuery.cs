using System.ComponentModel.DataAnnotations;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace TravelTeam.UseCases.Tour.GetTours
{
    /// <summary>
    /// Get tours query.
    /// </summary>
    public class GetToursQuery : IRequest<PagedListMetadataDto<TourInfoDto>>
    {
        [Required]
        public int? Page { get; set; }

        [Required]
        public int? PageSize { get; set; }
    }
}
