 
using CQRS_Decorator.Domain.Aggregates.UserAggregate;
using CQRSDecorate.Net.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.Application.Queries
{
    public record GetAllUserQuery() : IQuery<IEnumerable<User>>;

}
