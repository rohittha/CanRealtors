//using Realtor.API.Middleware;
//using Realtor.API.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Realtor.API.Common.Errors;
using Realtor.API.Common.Mapping;
using Realtor.API.Repository;
using Realtor.API.Services;

namespace Realtor.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            //services.AddControllers(options=> options.Filters.Add<ErrorHandlingFilterAttribute>());
            services.AddControllers();
            services.AddMappings();
            services.AddSingleton<ProblemDetailsFactory, RealtorsProblemDetailsFactory>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
