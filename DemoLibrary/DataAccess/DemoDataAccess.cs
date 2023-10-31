using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "Nawfel", LastName = "Hamdi", });
            people.Add(new PersonModel { Id = 2, FirstName = "Jhon", LastName = "Doe", });
        }
        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel GetPersonById(int id)
        {
            return people.FirstOrDefault(x => x.Id == id);
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new PersonModel { FirstName = firstName, LastName = lastName };

            var id = people.Max(x => x.Id) + 1;
            p.Id = id;

            people.Add(p);
            return p;
        }
    }
}
