using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Realtor.API.Common.Http;

namespace Realtor.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if(errors.Count is 0)
            {
                return Problem();
            }
            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblems(errors);
            }
            // We can add our custom logic for other type of errors. We can check using error.Type or error.NumericType

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            var firstError = errors[0];
            return SingleProblem(firstError);
        }

        private IActionResult SingleProblem(Error firstError)
        {
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }

        private IActionResult ValidationProblems(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }
    }
}
