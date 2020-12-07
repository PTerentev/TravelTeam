using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using TravelTeam.DataAccess;
using TravelTeam.UseCases.Common;
using System;
using System.Collections.Generic;

namespace TravelTeam.UseCases.Tour.CreateTour
{
    /// <summary>
    /// Create tour command handler.
    /// </summary>
    internal class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, IdResult<int>>
    {
        private readonly ILogger<CreateTourCommandHandler> logger;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CreateTourCommandHandler(ILogger<CreateTourCommandHandler> logger, ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.logger = logger;
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IdResult<int>> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            if (request.Date.ToUniversalTime() < DateTime.UtcNow)
            {
                var errors = new Dictionary<string, string>() { { "Tour date", "The tour`s date cannot be in the past!" } };
                throw new ValidationException(errors);
            }

            if (! await applicationDbContext.Users.AnyAsync(u => u.Id == request.CreatorUserId, cancellationToken))
            {
                throw new DomainException("Only authorized users can create tours!");
            }
            var tour = mapper.Map<Domain.Entities.Tour>(request);

            await using var transaction = await applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                applicationDbContext.Tours.Add(tour);
                await applicationDbContext.SaveChangesAsync();
                applicationDbContext.TourParticipants.Add(new Domain.Entities.TourParticipant()
                {
                    TourId = tour.Id,
                    UserId = tour.CreatorUserId
                });
                await applicationDbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }

            logger.LogTrace("A tour with id: {id} was created.", tour.Id);
            return new IdResult<int>(tour.Id);
        }
    }
}
