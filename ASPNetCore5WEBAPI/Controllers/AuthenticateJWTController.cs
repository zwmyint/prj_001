using ASPNetCore5WEBAPI.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore5WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateJWTController : ControllerBase
    {
        private readonly ITokenManagerJWT tokenManagerJWT;

        public AuthenticateJWTController(ITokenManagerJWT tokenManagerJWT)
        {
            this.tokenManagerJWT = tokenManagerJWT;
        }

        // https://localhost:5001/api/authenticatejwt?user=admin&pwd=password
        public IActionResult Authenticate(string user, string pwd)
        {
            if (tokenManagerJWT.Authenticate(user, pwd))
            {
                return Ok(new { Token = tokenManagerJWT.NewToken() });
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