using FluentValidation;
using InternalSite.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InternalSite.Application
{
    public static class Dependency
    {
        public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
        {
            return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Dependency).Assembly))
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() })
                .AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        }
    }
}
