using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelTeam.UseCases.User.GetInfo;
using TravelTeam.UseCases.User.Login;
using TravelTeam.UseCases.User.Register;

namespace TravelTeam.Web.Controllers
{
    /// <summary>
    /// Account API controller.
    /// </summary>
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : Controller
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
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {
            await mediator.Send(registerUserCommand, cancellationToken);
            return StatusCode(200);
        }

        /// <summary>
        /// Login user.
        /// </summary>
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(loginUserCommand, cancellationToken);
            return Json(result);
        }

        /// <summary>
        /// Get user info.
        /// </summary>
        public async Task<UserDto> GetInfo(GetUserInfoQuery getUserInfoQuery, CancellationToken cancellationToken)
        {
            return await mediator.Send(getUserInfoQuery, cancellationToken);
        }
    }
}
