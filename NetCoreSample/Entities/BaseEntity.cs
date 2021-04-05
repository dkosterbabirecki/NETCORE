using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}
