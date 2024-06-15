
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Realtor.Application.Authentication.Commands.Register;
using Realtor.Application.Authentication.Common;
using Realtor.Application.Common.Behaviors;
using System.Reflection;

namespace Realtor.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //services.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddMediatR(typeof(DependencyInjection).Assembly);
            //services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,ValidationBehavior>();
            //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}