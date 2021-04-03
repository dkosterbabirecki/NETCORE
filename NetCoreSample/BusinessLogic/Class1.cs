using System;
using DataAccess.Interface;
using Model;
using System.Linq;

namespace BusinessLogic

{
    public class PersonService
    {
        private IRepository<Person> repository;

        public PersonService(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        public IQueryable<Person> GetAll()
        {
            return repository.All.AsQueryable();
        }
    }
}
