using CQRS_Decorator.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Commands.CreateUser
{
    public record CreateUserCommand(string FirstName, string LastName, string Email) : ICommand<Guid>
    {
        public static CreateUserCommand Create(string firstName, string lastName, string email)
            => new(firstName, lastName, email);
    }

}
