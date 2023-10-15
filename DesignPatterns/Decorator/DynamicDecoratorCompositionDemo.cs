using DesignPatterns.Utils;
using System.Drawing;

namespace DesignPatterns.Decorator
{
    public interface IShape
    {
        string AsString();
    }

    public class Circle : IShape    
    {
        private int Radius;
        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public string AsString() => $"This is circle with radius : {Radius} ";
        
    }

    public class Square : IShape
    {
        private float Side;
        public Square(float side)
        {
            this.Side = side;
        }

        public string AsString() => $"This is square with side : {Side} ";

    }

    public class ColoredSquare : IShape
    {
        private Square Square;
        private string Color;
        public ColoredSquare(Square square, string color)
        {
            Square = square;
            this.Color = color;
        }
        public string AsString() => $"{Square.AsString()} has the color {Color}";

    }

    public class DynamicDecoratorCompositionDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var square = new Square(1.6f);
            Console.WriteLine(square.AsString());

            var coloredSquare = new ColoredSquare(square, "red");
            Console.WriteLine(coloredSquare.AsString());

        }
    }
}
