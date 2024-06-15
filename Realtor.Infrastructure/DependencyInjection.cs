
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Realtor.Application.Common.Interfaces.Authentication;
using Realtor.Infrastructure.Authentication;
using Realtor.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Realtor.Application.Common.Interfaces.Persistence;
using Realtor.Infrastructure.Persistence;

namespace Realtor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration
            )
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}