using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype.PrototypeInheritance
{
    public interface IDeepProtyable<T>  where T : new()
    {
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class Person : IDeepProtyable<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }
        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }
        public override string ToString()
        {
            return $"{nameof(Names)} : {string.Join(" ", Names)} " +
                   $"{nameof(Address)} : {Address}";
        }

        public void CopyTo(Person target)
        {
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
        }
    }
    public class Address : IDeepProtyable<Address>
    {
        public string ScreetName { get; set; }
        public int HouseNumber { get; set; }
        public Address()
        {

        }
        public Address(string screetName, int houseNumber)
        {
            ScreetName = screetName;
            HouseNumber = houseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(ScreetName)} : {ScreetName} " +
                   $"{nameof(HouseNumber)} : {HouseNumber}";
        }

        public void CopyTo(Address target)
        {
            target.ScreetName = ScreetName;
            target.HouseNumber = HouseNumber;
        }
    }

    public class Emplyee : Person, IDeepProtyable<Emplyee>
    {
        public int Salary { get; set; }
        public Emplyee()
        {

        }

        public Emplyee(string[] names, Address address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }

        public void CopyTo(Emplyee target)
        {
            target.Salary = Salary;
            base.CopyTo(target);
        }
    }

   public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepProtyable<T> item) where T : new()
        {
            return item.DeepCopy();
        }
        public static T DeepCopy<T>(this T person) where T : Person, new()
        {
            return ((IDeepProtyable<T>)person).DeepCopy();
        }
    }
    public class PrototypeInheritanceDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var nawfel = new Emplyee();

            nawfel.Names = new string[] {"Nawfel", "Hamdi"};
            nawfel.Address = new Address
            {
                ScreetName = "Tunis mood",
                HouseNumber = 123
            };
            nawfel.Salary = 100000;

            Console.WriteLine(nawfel);

            var jan = nawfel.DeepCopy();

            jan.Names = new string[] { "Jan", "jho" };
            jan.Salary = 500;
            Console.WriteLine(jan);
            Console.WriteLine(nawfel);
        }

    }
}
