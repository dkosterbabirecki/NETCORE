using Microsoft.EntityFrameworkCore;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Config.EntityConfigurations;

namespace DataAccess.Config
{
    public class EntityContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PersonCategory> PersonCategories { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {
        }
        public EntityContext()
        {
            // var options = new DbContextOptionsBuilder<MyDbContext>()
            //         .UseInMemoryDatabase(Guid.NewGuid().ToString())
            //       .Options;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    String connectionString = @"Server=localhost\SQLEXPRESS;Database=ORTTest;Trusted_Connection=True;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityContext).Assembly);
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
