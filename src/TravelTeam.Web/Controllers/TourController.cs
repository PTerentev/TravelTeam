using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;
using TravelTeam.UseCases.Tour;
using TravelTeam.UseCases.Tour.CreateTour;
using TravelTeam.UseCases.Tour.GetTourById;
using TravelTeam.UseCases.Tour.GetTours;
using TravelTeam.UseCases.Tour.ParticipateInTour;

namespace TravelTeam.Web.Controllers
{
    /// <summary>
    /// Tour API controller.
    /// </summary>
    [ApiController]
    [Route("api/[Controller]")]
    public class TourController : Controller
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
        public async Task<IActionResult> Create(CreateTourCommand createTourCommand, CancellationToken cancellationToken)
        {
            createTourCommand.CreatorUserId = GetUserId();
            await mediator.Send(createTourCommand, cancellationToken);
            return StatusCode(200);
        }

        /// <summary>
        /// Create tour.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Participate([Required] int tourId, CancellationToken cancellationToken)
        {
            var command = new ParticipateInTourCommand()
            {
                TourId = tourId,
                UserId = GetUserId()
            };

            await mediator.Send(command, cancellationToken);
            return StatusCode(200);
        }

        /// <summary>
        /// Get tours.
        /// </summary>
        public async Task<PagedListMetadataDto<TourInfoDto>> Get(GetToursQuery getToursQuery, CancellationToken cancellationToken)
        {
            return await mediator.Send(getToursQuery, cancellationToken);
        }

        /// <summary>
        /// Get tour by ID.
        /// </summary>
        public async Task<TourInfoDto> GetById(GetTourByIdQuery getTourByIdQuery, CancellationToken cancellationToken)
        {
            return await mediator.Send(getTourByIdQuery, cancellationToken);
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == ClaimTypes.Name).Value;
        }
    }
}
