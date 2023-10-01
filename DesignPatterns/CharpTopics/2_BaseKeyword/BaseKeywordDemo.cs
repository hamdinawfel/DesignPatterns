using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._2_BaseKeyword
{
    /// <summary>
    /// The base keyword is used to access members of the base class from within a derived class. Use it if you want to:
    /// - Call a method on the base class that has been overridden by another method.
    /// - Specify which base-class constructor should be called when creating instances of the derived class.
    /// </summary>
    public class Vehicule
    {
        protected string Maker;
        protected string Model;
        protected string Year;
        public Vehicule(string maker, string model, string year)
        {
            Maker = maker;
            Model = model;
            Year = year;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"{nameof(Maker)} : {Maker} : {nameof(Model)} : {Model} : {nameof(Year)} : {Year}");
        }

    }

    public class MyCar : Vehicule
    {
        public string OwnerName = "Ham";
        public MyCar(string maker, string model, string year) : base(maker, model, year)
        {
            
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"{nameof(OwnerName)} : {OwnerName}");
        }
    }
    public class BaseKeywordDemo : IExecuteDemo
    {
        public void Execute()
        {
           var mycar = new MyCar("BMV", "M8", "2023");
            mycar.GetInfo();
        }
    }
}
