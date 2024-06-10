
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Realtor.Application.Services.Authentication;
using Realtor.Contracts.Authentication;
using System.Reflection.Metadata.Ecma335;

namespace Realtor.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private IAuthenticatingService _authenticationService;
        public AuthenticationController(IAuthenticatingService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
                );


            return authResult.Match(authResult => Ok(NewMethod(authResult)),
                errors => Problem(errors));

            //return Ok(authResult);
        }

        static AuthenticationResponse NewMethod(ErrorOr<AuthenticationResult> authResult)
        {
            return new AuthenticationResponse(
                authResult.Value.User.Id,
                authResult.Value.User.FirstName,
                authResult.Value.User.LastName,
                authResult.Value.User.Email,
                authResult.Value.Token
                );
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password
                );

            //return Ok(response);

            return authResult.Match(authResult => Ok(NewMethod(authResult)),
                errors => Problem(errors));
        }
    }
}
