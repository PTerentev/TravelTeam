using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;
using TravelTeam.UseCases.Common;
using TravelTeam.UseCases.Tour.CreateTour;
using TravelTeam.UseCases.Tour.GetTourById;
using TravelTeam.UseCases.Tour.GetTours;
using TravelTeam.UseCases.Tour.GetToursByUser;
using TravelTeam.UseCases.Tour.ParticipateInTour;

namespace TravelTeam.Web.Controllers
{
    /// <summary>
    /// Tour API controller.
    /// </summary>
    [ApiController]
    [Route("api/tour")]
    public class TourController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TourController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Create tour.
        /// </summary>
        [Authorize]
        [HttpPost("create")]
        public async Task<IdResult<int>> Create([FromBody] CreateTourCommand createTourCommand, CancellationToken cancellationToken)
        {
            createTourCommand.CreatorUserId = GetUserId();
            return await mediator.Send(createTourCommand, cancellationToken);
        }

        /// <summary>
        /// Create tour.
        /// </summary>
        [Authorize]
        [HttpPost("participate")]
        public async Task<IActionResult> Participate([FromBody] ParticipateInTourCommand participateInTourCommand, CancellationToken cancellationToken)
        {
            participateInTourCommand.UserId = GetUserId();

            await mediator.Send(participateInTourCommand, cancellationToken);
            return StatusCode(200);
        }

        /// <summary>
        /// Get tours.
        /// </summary>
        [Authorize]
        [HttpGet("get-by-user")]
        public async Task<IEnumerable<TourDto>> GetByUser(CancellationToken cancellationToken)
        {
            var query = new GetToursByUserQuery()
            {
                UserId = GetUserId()
            };

            return await mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Get tours.
        /// </summary>
        [HttpGet("get")]
        public async Task<PagedListMetadataDto<TourDto>> Get([FromQuery] GetToursQuery getToursQuery, CancellationToken cancellationToken)
        {
            return await mediator.Send(getToursQuery, cancellationToken);
        }

        /// <summary>
        /// Get tour by ID.
        /// </summary>
        [HttpGet("get-by-id")]
        public async Task<TourDto> GetById([FromQuery] GetTourByIdQuery getTourByIdQuery, CancellationToken cancellationToken)
        {
            return await mediator.Send(getTourByIdQuery, cancellationToken);
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
