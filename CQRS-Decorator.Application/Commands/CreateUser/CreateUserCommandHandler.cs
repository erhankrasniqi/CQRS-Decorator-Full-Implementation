using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Application.Responses;
using CQRS_Decorator.Domain.Aggregates.UserAggregate;
using CQRS_Decorator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, GeneralResponse<Guid>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GeneralResponse<Guid>> HandleAsync(CreateUserCommand command)
        {
            var user = User.Create(command.FirstName, command.LastName, command.Email);
            await _userRepository.AddAsync(user);

            return new GeneralResponse<Guid>
            {
                Success = true,
                Message = "User created successfully.",
                Result = user.Id
            };
        }
    }
}