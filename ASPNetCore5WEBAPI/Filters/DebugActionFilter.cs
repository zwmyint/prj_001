using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNetCore5WEBAPI.Filters
{
    public class DebugActionFilter : ActionFilterAttribute
    {
        // in
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Console.WriteLine($"[Action filter:] {context.ActionDescriptor.DisplayName} is executing >>>");
            
        }

        // out
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            Console.WriteLine($"[Action filter:] {context.ActionDescriptor.DisplayName} is executed ---");
            
        }
    }

}