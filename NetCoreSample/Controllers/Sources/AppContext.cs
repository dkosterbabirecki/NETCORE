using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controllers
{
    public class AppContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        { }
        public AppContext()
        {
            // var options = new DbContextOptionsBuilder<MyDbContext>()
            //         .UseInMemoryDatabase(Guid.NewGuid().ToString())
            //       .Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = @"Server=localhost\SQLEXPRESS;Database=ORTTest;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
