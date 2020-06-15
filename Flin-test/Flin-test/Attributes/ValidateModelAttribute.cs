using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Flin_test.Attributes
{

    public class ValidateModelAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;
            if (modelState.IsValid)
            {
               await next();
            }
            context.Result = new BadRequestObjectResult("Invalid Modelstate!");
        }
    }
}
