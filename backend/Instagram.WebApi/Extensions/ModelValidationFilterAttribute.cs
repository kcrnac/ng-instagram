using System.Linq;
using System.Net;
using Instagram.Common.ErrorHandling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Instagram.WebApi.Extensions
{
    public class ModelValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var result = 
                    new ErrorResponse
                {
                    Status = (int) HttpStatusCode.BadRequest,
                    Errors = context.ModelState.Values
                        .SelectMany(p => p.Errors)
                        .Select(p => p.ErrorMessage)
                        .ToList()
                };

                context.Result = new BadRequestObjectResult(result);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
