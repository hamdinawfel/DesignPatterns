using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public class Person
    {
        public List<string> Names { get; set; }
        public Address Address { get; set; }

        public Person(List<string> names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }
        public override string ToString()
        {
            return $"{nameof(Names)} : {string.Join(" ",Names)}, {nameof(Address)} : {Address}";
        }
    }
    public class Address
    {
        public string ScreetName { get; set; }
        public int HouseNumber { get; set; }
        public Address(string screetName, int houseNumber)
        {
            ScreetName = screetName;
            HouseNumber = houseNumber;
        }

        public Address(Address otherAddress)
        {
            ScreetName = otherAddress.ScreetName;
            HouseNumber = otherAddress.HouseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(ScreetName)} : {ScreetName}, {nameof(HouseNumber)} : {HouseNumber}";
        }
    }

    public class PrototypeDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var nawfel = new Person(new List<string>() { "Nawfel", "Hamdi" }, new Address("Cite Khad", 123));
            Console.WriteLine(nawfel);

            var jan = new Person(nawfel);
            jan.Names = new List<string> { "Jan", "jho" };
            jan.Address.HouseNumber = 0;
            Console.WriteLine(jan);
            Console.WriteLine(nawfel);
        }

    }
}
