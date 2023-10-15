using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._5_DefaultInterfaceMembers
{
    /// <summary>
    /// C# 8.0 introduced default interface members, enabling the definition of methods in interfaces with default implementations.
    /// To access these default methods in implementing classes, you must either override the method or cast the instance to the interface type.
    /// </summary>

    public interface ICar
    {
        string Make { get; }
        public int GetTopSpeed() => 320;

    }

    public class MyCar : ICar
    {
        public string Make => "Golf";

    }
    public class Demo : IExecuteDemo
    {
        public void Execute()
        {
            var mycar = new MyCar();
            Console.WriteLine($"Manifuctred by :{mycar.Make}");
            // I can't access GetTopSpeed without override it for the class or without casting
            var maxSpeed = ((ICar)mycar).GetTopSpeed();
            Console.WriteLine($"Max Speed is :{maxSpeed}");


        }
    }
}
