using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNetCore5WEBAPI.Filters
{
    public class DebugResourceFilter : Attribute, IResourceFilter
    {

        // in
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"[Resource filter:] {context.ActionDescriptor.DisplayName} is executing >>>");
            //throw new NotImplementedException();
        }

        // out
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[Resource filter:] {context.ActionDescriptor.DisplayName} is executed ---");
            //throw new NotImplementedException();
        }

    }

}