using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factories
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private int nextId = 0;

        public Person CreatePerson(string name)
        {
            var person = new Person()
            {
                Id = nextId,
                Name = name
            };


            nextId++;

            return person;
        }
    }
    public class PersonFactoryDemo : IDemo
    {
        public void DisplayResult()
        {
            var factory = new PersonFactory();
            var person1 = factory.CreatePerson("Hamdi");
            Console.WriteLine($"{person1.Id}: {person1.Name}");
            var person2 = factory.CreatePerson("Nawfel");
            Console.WriteLine($"{person2.Id}: {person2.Name}");
        }
    }
}
