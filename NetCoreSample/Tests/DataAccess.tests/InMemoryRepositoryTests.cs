using System;
using Xunit;
using DataAccess;

namespace Tests
{
    public class InMemoryRepositoryTests
    {
        [Fact]
        public void AddValueSuccessfully()
        {
            var repository = new InMemoryRepository<String>();
            repository.Add("String");
            Assert.Equal(repository.First(str => str.Length > 0), "String");
        }
    }
}
