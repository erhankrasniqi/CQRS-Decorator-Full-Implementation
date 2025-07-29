using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Domain.Aggregates.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Queries
{
    public record GetAllUserQuery() : IQuery<IEnumerable<User>>;

}
