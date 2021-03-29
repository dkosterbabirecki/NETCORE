using System;
using Controllers;
using Model;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var controller = new PersonController(new EFDataProvider<Person>(new Controllers.AppContext()));
            var person = new Person();
            person.Email = "email20";
            person.Age = 21;
            person.Name = "nombre";
            controller.Add(person);
            var persons = controller.Persons();
            Console.WriteLine(persons.ToString());
        }
    }
}
