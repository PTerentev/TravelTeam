using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelTeam.Abstractions.Data;

namespace TravelTeam.UseCases.Tour.CreateTour
{
    /// <summary>
    /// Create tour command handler.
    /// </summary>
    internal class CreateTourCommandHandler : IRequestHandler<CreateTourCommand>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CreateTourCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = mapper.Map<Domain.Entities.Tour>(request);

            applicationDbContext.Tours.Add(tour);

            applicationDbContext.TourParticipants.Add(new Domain.Entities.TourParticipant()
            {
                TourId = tour.Id,
                UserId = tour.CreatorUserId
            });

            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
