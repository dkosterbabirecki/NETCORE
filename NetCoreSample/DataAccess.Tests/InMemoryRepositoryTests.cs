using System;
//using Xunit;
using DataAccess.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    public class InMemoryRepositoryTests
    {
        // var options = new DbContextOptionsBuilder<MyDbContext>()
        //         .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //       .Options;
        [TestMethod]
        public void AddValueSuccessfully()
        {
            var repository = new InMemoryRepository<String>();
            repository.Add("String");
            //Assert.Equal(repository.First(str => str.Length > 0), "String");
        }

        [TestMethod]
        public void AddExistingValue()
        {
            var repository = new InMemoryRepository<String>();
            repository.Add("String");
            repository.Add("String");
            //Assert.Equal(repository.First(str => str.Length > 0), "String");
        }
    }
}
