using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace DataAccess.Config.EntityConfigurations
{
    class PersonCategoryConfiguration : IEntityTypeConfiguration<PersonCategory>
    {
        public void Configure(EntityTypeBuilder<PersonCategory> builder)
        {
            builder.HasKey(personCategory => new { personCategory.CategoryId, personCategory.PersonId });
            builder.HasOne(pc => pc.Category)
                   .WithMany(c => c.PersonCategories)
                   .HasForeignKey(pc => pc.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(pc => pc.Person)
                   .WithMany(p => p.PersonCategories)
                   .HasForeignKey(pc => pc.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
