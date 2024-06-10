using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using Realtor.Application.Services.Authentication;

namespace Realtor.Application.Services.Authentication
{
    public interface IAuthenticatingService
    {
        //AuthenticationResult Register(string firstName, string lastName, string email, string password);
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

        //AuthenticationResult Login(string email, string password);
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
