using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Domain.Aggregates.UserAggregate;
using CQRS_Decorator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> HandleAsync(CreateUserCommand command)
        {
            var user = User.Create(command.FirstName, command.LastName, command.Email);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }


}
