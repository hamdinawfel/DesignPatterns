using DesignPatterns.Utils;

namespace DesignPatterns.Decorator.StaticDecorator
{
    public class StaticDecoratorCompositionDemo : IDisplayDemo
    {
        public abstract class Shape
        {
            public abstract string AsString();
        }

        public class Circle : Shape
        {
            private int Radius;

            public Circle() : this(0)
            {

            }
            public Circle(int radius)
            {
                this.Radius = radius;
            }

            public override string AsString() => $"This is circle with radius : {Radius} ";

        }

        public class Square : Shape
        {
            private float Side;

            public Square() : this(0.0f)
            {

            }
            public Square(float side)
            {
                this.Side = side;
            }

            public override string AsString() => $"This is square with side : {Side} ";

        }

        public class ColoredShape<T> : Shape  where T : Shape, new()
        {
            private string color;
            private T shape = new T();

            public ColoredShape() : this("balck")
            { 

            }
            public ColoredShape(string color)
            {
                this.color = color;
            }
            public override string AsString() => $"{shape.AsString()} has the color {color}";

        }

        public class TransparentShape<T> : Shape where T : Shape, new()
        {
            private float transparency;
            private T shape = new T();

            public TransparentShape(): this(100.00f)
            {

            }
            public TransparentShape(float transparency)
            {
                this.transparency = transparency;
            }
            public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f} % Transparency";

        }

        public void DisplayResult()
        {
            var coloredSquare = new ColoredShape<Square>("white");
            Console.WriteLine(coloredSquare.AsString());


            var circle = new TransparentShape<ColoredShape<Circle>>(0.05f);
            Console.WriteLine(circle.AsString());
        }
    }
}
