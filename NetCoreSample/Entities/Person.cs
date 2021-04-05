using System;

namespace Entities
{
    public class Person : BaseEntity
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
