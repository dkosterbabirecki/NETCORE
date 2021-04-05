using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public String Name { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public virtual ICollection<PersonCategory> PersonCategories { get; set; }
    }
}
