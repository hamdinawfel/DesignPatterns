using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public class Point
    {
        public int X, Y;

        public override string ToString()
        {
            return $"{nameof(X)} : {X}, {nameof(Y)} : {Y}";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var newStart = new Point { X = Start.X, Y = Start.Y };
            var newEnd = new Point { X = End.X, Y = End.Y };
            return new Line { Start = newStart, End = newEnd };
        }

        public override string ToString()
        {
            return $"{nameof(Start)} : {Start}, {nameof(End)} : {End}";
        }
    }
    public class PrototypeExecrice : IDisplayDemo
    {
        public void DisplayResult()
        {

            var line1 = new Line
            {
                Start = new Point { X = 3, Y = 3 },
                End = new Point { X = 10, Y = 10 }
            };
            Console.WriteLine(line1);
            var line2 = line1.DeepCopy();
            line2.End = new Point { X = 20, Y = 30 };

            Console.WriteLine(line1);
            Console.WriteLine(line2);
        }
    }
}
