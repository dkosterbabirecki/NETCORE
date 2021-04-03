using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class EntityContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

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
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
