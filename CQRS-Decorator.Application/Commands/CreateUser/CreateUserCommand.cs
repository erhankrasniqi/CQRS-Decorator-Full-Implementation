using CQRS_Decorator.Application.Responses;
using CQRSDecorate.Net.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Commands.CreateUser
{
    public record CreateUserCommand(string FirstName, string LastName, string Email)
    : ICommand<GeneralResponse<Guid>>
    {
        public static CreateUserCommand Create(string firstName, string lastName, string email)
            => new(firstName, lastName, email);
    }


}
