using System;
using System.Linq;
using ASPNetCore5WEBAPI.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNetCore5WEBAPI.Filters
{
    public class TokenAuthenticationJWTFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            // a bit special here for ITokenManager
            var tokenManager = (ITokenManagerJWT)context.HttpContext.RequestServices.GetService(typeof(ITokenManagerJWT));
            //

            var result = true;
            if(!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                result = false;
            }

            string token = string.Empty;
            if(result) // True
            {
                token = context.HttpContext.Request.Headers.First( x => x.Key == "Authorization").Value;
                try
                {
                    var ClaimsPrincipal = tokenManager.VerifyToken(token);
                }
                catch(Exception ex){
                    result = false;
                    context.ModelState.AddModelError("Unauthorized", ex.ToString());
                }
            }

            if(!result) // False
            {
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }


            //throw new NotImplementedException();
        }


        //
    }

    //
}