using System;
using System.Collections.Generic;
using System.Linq;
 
namespace CQRS_Decorator.SharedKernel
{
    public class Entity
    {
        public Guid Id { get; protected set; } 
        public DateTime CreatedOn { get; protected set; }
        public DateTime? ModifiedOn { get; protected set; }
    }
}
