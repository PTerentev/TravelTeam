using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelTeam.DataAccess;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.GetToursByUser
{
    internal class GetToursByUserQueryHandler : IRequestHandler<GetToursByUserQuery, IEnumerable<TourDto>>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GetToursByUserQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TourDto>> Handle(GetToursByUserQuery request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.Tours
                .Where(t => t.CreatorUserId == request.UserId)
                .Select(t => mapper.Map<TourDto>(t))
                .ToListAsync(cancellationToken);
        }
    }
}
