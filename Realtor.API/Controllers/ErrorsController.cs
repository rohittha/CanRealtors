using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Realtor.API.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            // TODO understand how ex? works
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            //var (statusCode, message) = exception switch
            //{
            //    DuplicateEmailException => (StatusCodes.Status409Conflict, "Emial exists!!!"),
            //    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured!"),
            //};
            //return Problem(statusCode: statusCode, title: message);

            return Problem(title: exception?.Message, statusCode: 400);
        }
    }
}
