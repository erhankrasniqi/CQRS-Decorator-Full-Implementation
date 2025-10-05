 
using CQRS_Decorator.Domain.Aggregates.UserAggregate;
using CQRS_Decorator.Domain.Interfaces;
using CQRSDecorate.Net.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Queries
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> HandleAsync(GetAllUserQuery query)
        {
            return await _userRepository.GetAllAsync();
        }
    }

}
