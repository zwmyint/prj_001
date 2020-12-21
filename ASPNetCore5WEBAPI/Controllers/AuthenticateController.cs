using ASPNetCore5WEBAPI.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore5WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenManager tokenManager;

        public AuthenticateController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        // https://localhost:5001/api/authenticate?user=admin&pwd=password
        public IActionResult Authenticate(string user, string pwd)
        {
            if (tokenManager.Authenticate(user, pwd))
            {
                return Ok(new { Token = tokenManager.NewToken() });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not unauthorized.");
                return Unauthorized(ModelState);
            }
        }

        //
    }

    //
}