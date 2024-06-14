using ErrorOr;
using MediatR;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Domain.Common.Errors;
using Realtor.Domain.Entities;

namespace Realtor.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            //1. Check if user exists
            if (_userRepository.GetUserByEmail(request.Email) is not User user)     // TODO check what does this mean: is not User user
            {
                //throw new Exception("User with given email does not exist!");
                return Errors.Authentication.InvalidCredentials;
            }

            //2. Check if password correct
            if (user.Password != request.Password)
            {
                //throw new Exception("Invalid password!");
                return Errors.Authentication.InvalidCredentials;
            }
            //3. Create JWT token for the new user
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
