using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)} : {Position}";
        }
        public class Builder : PersonPositionBuilder<Builder>
        {
           
        }

        public static Builder New => new Builder();
    }

    public class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where  SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name; 
            return (SELF)this;    
        }
    }

    public class PersonPositionBuilder<SELF> 
        : PersonInfoBuilder<PersonPositionBuilder<SELF>>
        where SELF : PersonPositionBuilder<SELF>
    {
        public SELF WorkAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
    public class FluentBuilderInheritanceWithRecusrsiveGenericsDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var me = Person.New
                           .Called("nawfel")
                           .WorkAs("c# programer")
                           .Build();

            Console.WriteLine(me);
        }
    }
}
