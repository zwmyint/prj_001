using System;
using System.Linq;
using ASPNetCore5WEBAPI.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNetCore5WEBAPI.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            // a bit special here for ITokenManager
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
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
                if (!tokenManager.VerifyToken(token))
                {
                    result = false;
                }

            }

            if(!result) // False
            {
                context.ModelState.AddModelError("Unauthorized", "You are not authorized.");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }


            //throw new NotImplementedException();
        }


        //
    }

    //
}