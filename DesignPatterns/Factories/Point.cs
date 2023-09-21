using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factories
{
    public class PointWithoutFactoryMethod
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        private double x;
        private double y;

        public PointWithoutFactoryMethod(double a, double b, CoordinateSystem coordinateSystem = CoordinateSystem.Cartesian)
        {
            switch (coordinateSystem)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;

                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
            }
        }

        public override string ToString()
        {
            return $"{nameof(x)} : {x}, {nameof(y)} : {y}";
        }
    }


    // Point class with Factory Method

    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)} : {x}, {nameof(y)} : {y}";
        }

        public static class Factory
        {
            public static Point NewCartisienCoordinate(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarCoordinate(double rho, double teta)
            {
                return new Point(rho * Math.Cos(teta), rho * Math.Sin(teta));
            }
        }
    }

    public class PointFactroyDemo : IDemo
    {
        public void DisplayResult()
        {
            var a =  Point.Factory.NewPolarCoordinate(1.0, Math.PI /2);
            Console.WriteLine(a);

            var b = new PointWithoutFactoryMethod(1.0, Math.PI / 2, PointWithoutFactoryMethod.CoordinateSystem.Polar);
            Console.WriteLine(b);
        }
    }
}
