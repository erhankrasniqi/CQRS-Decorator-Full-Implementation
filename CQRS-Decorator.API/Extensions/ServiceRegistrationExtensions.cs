 
using CQRS_Decorator.Application.Commands.CreateUser; 
using CQRS_Decorator.Application.Responses;
using CQRS_Decorator.Decorators;
using CQRS_Decorator.Domain.Interfaces;
using CQRS_Decorator.Infrastructure.Repositories;
using CQRSDecorate.Net;
using CQRSDecorate.Net.Abstractions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRS_Decorator.API.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            services.RegisterCqrsDecorator(typeof(CreateUserCommandHandler));

            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

            // Decorators
            services.Decorate<ICommandHandler<CreateUserCommand, GeneralResponse<Guid>>, ValidationDecorator<CreateUserCommand, GeneralResponse<Guid>>>();
            services.Decorate<ICommandHandler<CreateUserCommand, GeneralResponse<Guid>>, LoggingDecorator<CreateUserCommand, GeneralResponse<Guid>>>();



           
        }
         
    }
}
