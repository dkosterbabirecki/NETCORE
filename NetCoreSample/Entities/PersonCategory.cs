using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PersonCategory
    {
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
