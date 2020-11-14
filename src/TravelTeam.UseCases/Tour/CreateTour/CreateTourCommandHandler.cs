using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using TravelTeam.DataAccess;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.CreateTour
{
    /// <summary>
    /// Create tour command handler.
    /// </summary>
    internal class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, IdResult<int>>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CreateTourCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IdResult<int>> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            if (! await applicationDbContext.Users.AnyAsync(u => u.Id == request.CreatorUserId, cancellationToken))
            {
                throw new DomainException("Only authorized users can create tours!");
            }

            var tour = mapper.Map<Domain.Entities.Tour>(request);

            applicationDbContext.Tours.Add(tour);

            applicationDbContext.TourParticipants.Add(new Domain.Entities.TourParticipant()
            {
                TourId = tour.Id,
                UserId = tour.CreatorUserId
            });

            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return new IdResult<int>(tour.Id);
        }
    }
}
