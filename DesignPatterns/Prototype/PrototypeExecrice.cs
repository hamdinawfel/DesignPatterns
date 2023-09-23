using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public interface IProtype<T>
    {
        T DeepCopy();
    }
    public class Point : IProtype<Point>
    {
        public int X, Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point DeepCopy()
        {
            return new Point(X, Y);
        }

        public override string ToString()
        {
            return $"{nameof(X)} : {X}, {nameof(Y)} : {Y}";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
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
            var startPoint = new Point(0, 0);
            var endPoint = new Point(1, 1);

            var line1 = new Line(startPoint, endPoint);
            var line2 = line1.DeepCopy();
            Console.WriteLine(line1);

            line2.Start = new Point(2, 2);

            Console.WriteLine(line1);
            Console.WriteLine(line2);
        }
    }
}
