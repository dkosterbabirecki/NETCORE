using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Entities
{
    public class Person : BaseEntity
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public virtual ICollection<PersonCategory> PersonCategories { get; set; }
    }
}
