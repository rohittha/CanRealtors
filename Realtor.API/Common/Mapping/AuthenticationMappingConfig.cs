using Mapster;
using Realtor.Application.Authentication.Commands.Register;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Authentication.Queries.Login;
using Realtor.Contracts.Authentication;

namespace Realtor.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                    .Map(dest => dest, src => src.User);

        }
    }
}
