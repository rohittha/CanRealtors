using ErrorOr;
using MediatR;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Domain.Entities;
using Realtor.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Realtor.Application.Authentication.Common;

namespace Realtor.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            //1. Check if user exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                //throw new Exception("User with given email already exists!");
                //throw new DuplicateEmailException();
                return Errors.User.DuplicateEmail;
            }

            //2. Register a NEW user
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
            };

            _userRepository.Add(user);

            //3. Create JWT token for the new user
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }
    }
}
