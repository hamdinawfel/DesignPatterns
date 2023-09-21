using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.Factories.HotDrinkMachine;

namespace DesignPatterns.Factories
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Tea is consuming ...");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Coffee is consuming ...");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Prepare {amount} ml, of Tea");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Prepare {amount} ml, of Coffee");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                  Type.GetType("DesignPatterns.Factories." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    public class HotDrinkMachineDemo : IDemo
        {
            public void DisplayResult()
            {
                var machine = new HotDrinkMachine();
                var drink = machine.MakeDrink(AvailableDrink.Tea, 100);
                drink.Consume();
            }
        }
    }
