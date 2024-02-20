using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.AdvancedTopics.InParameters
{
    public struct Point
    {
        public double X, Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }

    public class Demo
    {
        //public double MeaserDistance(Point p1, Point p2)
        //{
        //    var dx = p1.X - p2.X;
        //    var dy = p1.Y - p2.Y;


        //}
    }

    public class InParametresDemo : IExecuteDemo
    {
        public void Execute()
        {
            
        }
    }
}
