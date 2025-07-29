using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Application.Commands.CreateUser;
using CQRS_Decorator.Application.Dispatchers;
using CQRS_Decorator.Decorators;
using CQRS_Decorator.Domain.Interfaces;
using CQRS_Decorator.Infrastructure.Repositories;
using FluentValidation;
using CQRS_Decorator.Application.Responses;

namespace CQRS_Decorator.API.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Dispatcher
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            // Handlers (optional if using automatic)
            // services.AddScoped<ICommandHandler<CreateUserCommand, Guid>, CreateUserCommandHandler>();
            // services.AddScoped<IQueryHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();

            // Register all handlers automatically
            services.AddHandlersAutomatically();

            // Decorators
            services.Decorate<ICommandHandler<CreateUserCommand, GeneralResponse<Guid>>, ValidationDecorator<CreateUserCommand, GeneralResponse<Guid>>>();
            services.Decorate<ICommandHandler<CreateUserCommand, GeneralResponse<Guid>>, LoggingDecorator<CreateUserCommand, GeneralResponse<Guid>>>();

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
        }

        public static void AddHandlersAutomatically(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                typeof(CreateUserCommand).Assembly  
            };

            var handlerInterfaceTypes = new[]
            {
                typeof(ICommandHandler<,>),
                typeof(IQueryHandler<,>)
            };

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                foreach (var handlerType in handlerInterfaceTypes)
                {
                    var implementations = types
                        .Where(t => !t.IsAbstract && !t.IsInterface)
                        .SelectMany(t =>
                            t.GetInterfaces()
                             .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerType)
                             .Select(i => new { ServiceType = i, ImplementationType = t })
                        );

                    foreach (var impl in implementations)
                    {
                        services.AddScoped(impl.ServiceType, impl.ImplementationType);
                    }
                }
            }
        }
    }
}
