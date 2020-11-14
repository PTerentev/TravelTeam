using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelTeam.Abstractions.Data;

namespace TravelTeam.UseCases.Tour.GetTourById
{
    /// <summary>
    /// Get tour info by ID query handler.
    /// </summary>
    internal class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, TourInfoDto>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetTourByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<TourInfoDto> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var tour = await applicationDbContext.Tours
                .Include(t => t.CreatorUser)
                .Include(t => t.MovementType)
                .SingleAsync(t => t.Id == request.TourId, cancellationToken);

            return mapper.Map<TourInfoDto>(tour);
        }
    }
}
