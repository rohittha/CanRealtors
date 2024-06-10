using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Realtor.API.Common.Http;

namespace Realtor.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            // TODO complete logic after model vaidation in our service. Right now just take 1st error
            //HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            var firstError = errors[0];
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}
