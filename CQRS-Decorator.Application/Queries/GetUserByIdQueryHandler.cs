using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Domain.Entities;
using CQRS_Decorator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Queries
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandleAsync(GetUserByIdQuery query)
        {
            return await _userRepository.GetByIdAsync(query.Id);
        }
    }

}
