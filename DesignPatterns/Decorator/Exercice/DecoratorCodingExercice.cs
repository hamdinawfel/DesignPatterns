using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Exercice
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon
    {
        private int age;
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        public int Age
        {
            get { return age; }
            set
            {
                bird.Age = value;
                lizard.Age = value;
            }
        }

        
        public string Crawl()
        {
             return lizard.Crawl();
        }

        public string Fly()
        {
            return bird.Fly();
        }
    }
    public class DecoratorCodingExercice : IDisplayDemo
    {
        public void DisplayResult()
        {
            var b = new Bird();
            b.Age = 10;
            var l = new Lizard();
            l.Age = 10;
           
            var d = new Dragon();

            var result1 = d.Crawl();
            var result2 = d.Fly();

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
