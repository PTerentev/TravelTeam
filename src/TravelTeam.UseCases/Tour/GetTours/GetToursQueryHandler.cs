using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;
using TravelTeam.Abstractions.Data;

namespace TravelTeam.UseCases.Tour.GetTours
{
    /// <summary>
    /// Get tours query handler.
    /// </summary>
    internal class GetToursQueryHandler : IRequestHandler<GetToursQuery, PagedListMetadataDto<TourInfoDto>>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetToursQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<PagedListMetadataDto<TourInfoDto>> Handle(GetToursQuery request, CancellationToken cancellationToken)
        {
            var paged = await EFPagedListFactory
                .FromSourceAsync(applicationDbContext.Tours
                                .Include(t => t.CreatorUser)
                                .Include(t => t.MovementType)
                                .OrderByDescending(t => t.CreatedDate),
                request.Page.GetValueOrDefault(),
                request.PageSize.GetValueOrDefault(),
                cancellationToken);

            var paged2 = paged.Convert(p => mapper.Map<TourInfoDto>(p));
            return paged2.ToMetadataObject();
        }
    }
}
