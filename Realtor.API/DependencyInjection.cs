using Microsoft.EntityFrameworkCore.Metadata;
using Realtor.API.Services;
using Realtor.API.Repository;
using System.Runtime.CompilerServices;
using Realtor.API.Data;
using Microsoft.EntityFrameworkCore;
using Realtor.Application.Services.Authentication;
//using Realtor.API.Middleware;
//using Realtor.API.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Realtor.API.Common.Errors;

namespace Realtor.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            //services.AddControllers(options=> options.Filters.Add<ErrorHandlingFilterAttribute>());
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, RealtorsProblemDetailsFactory>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
