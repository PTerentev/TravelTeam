using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using TravelTeam.DataAccess;

namespace TravelTeam.UseCases.Tour.ParticipateInTour
{
    /// <summary>
    /// Participate in tour command handler.
    /// </summary>
    internal class ParticipateInTourCommandHandler : IRequestHandler<ParticipateInTourCommand>
    {
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ParticipateInTourCommandHandler(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(ParticipateInTourCommand request, CancellationToken cancellationToken)
        {
            if (! await applicationDbContext.Tours.AnyAsync(t => t.Id == request.TourId, cancellationToken))
            {
                throw new NotFoundException($"Cannot find the tour with Id: {request.TourId}");
            }

            if (await applicationDbContext.TourParticipants.AnyAsync(t => t.UserId == request.UserId && t.TourId == request.TourId, cancellationToken))
            {
                throw new DomainException($"The user already participates in the tour.");
            }

            var participate = new Domain.Entities.TourParticipant()
            {
                TourId = request.TourId,
                UserId = request.UserId
            };

            applicationDbContext.TourParticipants.Add(participate);

            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
