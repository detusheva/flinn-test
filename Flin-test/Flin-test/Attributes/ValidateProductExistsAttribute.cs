using Flin_test.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flin_test.Attributes
{
    public class ValidateProductExistsAttribute : TypeFilterAttribute
    {
        public ValidateProductExistsAttribute() : base(typeof(ValidateProductExistsFilterImpl))
        {
        }

        private class ValidateProductExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IProductRepository _productRepository;

            public ValidateProductExistsFilterImpl(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (context.ActionArguments.ContainsKey("id"))
                {
                    var id = context.ActionArguments["id"] as Guid?;
                    if (id.HasValue)
                    {
                        if ((await _productRepository.GetAllProducts(null)).All(a => a.ProductId != id.Value))
                        {
                            context.Result = new NotFoundObjectResult(string.Format("Product Id doesn't exist : {0}", id.Value));
                            return;
                        }
                    }
                }
                await next();
            }
        }
    }
}
