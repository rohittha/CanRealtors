using ErrorOr;
using MediatR;
using Realtor.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
