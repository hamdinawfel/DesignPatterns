using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public interface ICreature
    {
        int Age { get; set; }
    }

    public interface IBird2 : ICreature
    {
        public void Fly()
        {
            if(Age>= 10)
            {
                Console.WriteLine("Can Flying");
            }
        }
    }

    public interface ILizard2 : ICreature
    {
        public void Crawl()
        {
            if (Age < 10)
            {
                Console.WriteLine("Can Crawling");
            }
        }
    }

    // created to similate that Dragon2 class can't inherint behavior form other class ,
    // we can add behavior Extension methods or with default interface member like this demo
    public class Organism { }
    public class Dragon2: Organism, IBird2, ILizard2
    {
        public int Age { get; set; }

    }

    public class MultipleInheritanceWithDefaultInterfaceMemberDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            Dragon2 d = new Dragon2 { Age = 5 };


            //((IBird2)d).Fly();
            if (d is IBird2 bird)
            {
                bird.Fly();
            } 

            // ((ILizard2)d).Crawl();
            if (d is ILizard2 lizard)
            {
                lizard.Crawl();
            }
        }
    }
}
