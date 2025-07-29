using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Decorator.SharedKernel
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<Guid>
    {
        //
    }
}
