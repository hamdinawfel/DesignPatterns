using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(name)} : {name}, {nameof(age)} : {age}";
        }
    }
    public class SingletonMonostateDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var ceo1 = new CEO();
            ceo1.Name = "Nawfel";
            ceo1.Age = 0001;

            var ceo2 = new CEO();
            ceo1.Name = "Hamdi";
            ceo1.Age = 0002;

            Console.WriteLine(ceo1);
            Console.WriteLine(ceo2);
        }
    }
}
