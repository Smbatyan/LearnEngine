using LearnEngine.Application.ResponseModels.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearnEngine.API.Attributes
{
    public class ValidatorModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Any())
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();

                List<ErrorResponse> errorResponses = new();

                foreach (var errorMessage in errors)
                {
                    errorResponses.Add(new ErrorResponse() { Message = errorMessage });
                }

                context.Result = new JsonResult(errorResponses)
                {
                    StatusCode = 400
                };
            }
        }
    }
}
