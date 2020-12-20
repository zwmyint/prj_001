using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Controllers    
{    
 
    //https://github.com/jignesht24/Aspnetcore/tree/master/JWTAuthentication
    //https://www.c-sharpcorner.com/article/jwt-json-web-token-authentication-in-asp-net-core/#:~:text=JWT%20(JSON%20web%20token)%20become,a%20secure%20and%20compact%20way.

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase    
    { 
        private IConfiguration _config;    
    
        public LoginController(IConfiguration config)    
        {    
            _config = config;    
        }   

        [AllowAnonymous]    
        [HttpPost]    
        public IActionResult Login([FromBody]UserModel login)    
        {    
            IActionResult response = Unauthorized();    
            var user = AuthenticateUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                response = Ok(new { token = tokenString });    
            }    
    
            return response;    
        }

        private string GenerateJSONWebToken(UserModel userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              claims,    
              expires: DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
        private UserModel AuthenticateUser(UserModel login)    
        {    
            UserModel user = null;    
    
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username == "zwmyint")    
            {    
                user = new UserModel { Username = "zaw win myint", EmailAddress = "test@gmail.com" };    
            }    
            return user;    
        } 

        

        //
    }

    //
}