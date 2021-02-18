using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Security.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ITokenService _tokenService;

        public AuthorizationController(IAuthorizationService authorizationService, ITokenService tokenService)
        {
            _authorizationService = authorizationService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public ActionResult Login([FromBody]LoginModel model)
        {
            var user = _authorizationService.Authorize(model.User, model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.CreateToken(user);

            return Ok(new {type = "Bearer", access = token});
        }
    }
}
