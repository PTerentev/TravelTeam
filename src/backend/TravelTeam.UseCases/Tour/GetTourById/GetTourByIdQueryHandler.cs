using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelTeam.DataAccess;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.GetTourById
{
    /// <summary>
    /// Get tour info by ID query handler.
    /// </summary>
    internal class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, TourDto>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetTourByIdQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<TourDto> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var tour = await applicationDbContext.Tours
                .Include(t => t.CreatorUser)
                .Include(t => t.TourParticipants)
                .FirstAsync(t => t.Id == request.TourId, cancellationToken);

            return mapper.Map<TourDto>(tour);
        }
    }
}
