using ErrorOr;
using Realtor.Application.Common.Errors;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Domain.Common.Errors;
using Realtor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Application.Services.Authentication
{
    public class AuthenticatingService : IAuthenticatingService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthenticatingService( IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //1. Check if user exists
            if (_userRepository.GetUserByEmail(email) is not User user)     // TODO check what does this mean: is not User user
            {
                //throw new Exception("User with given email does not exist!");
                return Errors.Authentication.InvalidCredentials;
            }

            //2. Check if password correct
            if (user.Password != password)
            {
                //throw new Exception("Invalid password!");
                return Errors.Authentication.InvalidCredentials;
            }
            //3. Create JWT token for the new user
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }


        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1. Check if user exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                //throw new Exception("User with given email already exists!");
                //throw new DuplicateEmailException();
                return Errors.User.DuplicateEmail;
            }

            //2. Register a NEW user
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
            };

            _userRepository.Add(user);

            //3. Create JWT token for the new user
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }
    }
}
