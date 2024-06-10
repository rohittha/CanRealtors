
using Microsoft.Extensions.DependencyInjection;
using Realtor.Application.Services.Authentication;

namespace Realtor.API.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticatingService,AuthencatingService>();
            return services;
        }
    }
}