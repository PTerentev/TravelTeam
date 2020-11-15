using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelTeam.UseCases.Common;
using TravelTeam.UseCases.User.GetInfo;
using TravelTeam.UseCases.User.Login;
using TravelTeam.UseCases.User.Register;

namespace TravelTeam.Web.Controllers
{
    /// <summary>
    /// Account API controller.
    /// </summary>
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Register user.
        /// </summary>
        [HttpPost("register")]
        public async Task<IdResult<string>> Register([FromQuery] RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {
            return await mediator.Send(registerUserCommand, cancellationToken);
        }

        /// <summary>
        /// Login user.
        /// </summary>
        [HttpGet("login")]
        public async Task<LoginUserCommandResult> Login([FromQuery] LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
        {
            return await mediator.Send(loginUserCommand, cancellationToken);
        }

        /// <summary>
        /// Get user info.
        /// </summary>
        [HttpGet("get")]
        public async Task<UserDto> GetInfo([FromQuery] GetUserInfoQuery getUserInfoQuery, CancellationToken cancellationToken)
        {
            return await mediator.Send(getUserInfoQuery, cancellationToken);
        }
    }
}
