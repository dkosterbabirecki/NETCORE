using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataAccess;

namespace Controllers
{
    public class PersonController
    {
        private IDataProvider<Person> dataProvider;

        public PersonController(IDataProvider<Person> dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public IEnumerable<Person> Persons()
        {
            return dataProvider.repository.All;
        }

        public void Add(Person person)
        {
            dataProvider.repository.Add(person);
            dataProvider.Save();
        }
    }
}
