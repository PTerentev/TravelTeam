using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;
using TravelTeam.DataAccess;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.GetTours
{
    /// <summary>
    /// Get tours query handler.
    /// </summary>
    internal class GetToursQueryHandler : IRequestHandler<GetToursQuery, PagedListMetadataDto<TourDto>>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetToursQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PagedListMetadataDto<TourDto>> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            var paged = await EFPagedListFactory
                .FromSourceAsync(applicationDbContext.Tours
                                .OrderByDescending(t => t.CreatedDate),
                                request.Page,
                                request.PageSize,
                                cancellationToken);

            var paged2 = paged.Convert(p => mapper.Map<TourDto>(p));
            return paged2.ToMetadataObject();
        }
    }
}
