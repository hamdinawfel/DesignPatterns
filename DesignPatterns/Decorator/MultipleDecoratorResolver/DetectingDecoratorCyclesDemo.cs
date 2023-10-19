
using DesignPatterns.Utils;
using System.Text;

namespace DesignPatterns.Decorator.MultipleDecoratorResolver
{
    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        private int Radius;
        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public override string AsString() => $"This is circle with radius : {Radius} ";

    }

    public class Square : Shape
    {
        private float Side;
        public Square(float side)
        {
            this.Side = side;
        }

        public override string AsString() => $"This is square with side : {Side} ";

    }

    public class ColoredShape : ShapeDecorator<ColoredSquare, AbsorbCyclePolicy> //AllowCyclePolicy, ThrowOnCyclePolicy, AbsorbCyclePolicy
    {
        private Shape shape;
        private string color;
        public ColoredShape(Shape shape, string color) : base(shape)
        {
            this.shape = shape;
            this.color = color;
        }
        public override string AsString()
        {
            var sb = new StringBuilder($"{shape.AsString()} has the color {color}");
            if (policy.ApplicationAllowed(types[0], types.Skip(1).ToList()))
                sb.Append($"has the color {color}");
            return sb.ToString();
        }

    }

    public abstract class ShapeDecoratorCyclePolicy
    {
        public abstract bool TypeAdditionAllowed(Type type, IList<Type> allTypes);
        public abstract bool ApplicationAllowed(Type type, IList<Type> allTypes);
    }

    public class ThrowOnCyclePolicy : ShapeDecoratorCyclePolicy
    {
        private bool handler(Type type, IList<Type> allTypes)
        {
            if (allTypes.Contains(type))
            {
                throw new InvalidOperationException(
                    $"Cycle detected!, Type of {type.FullName} is already exist");
            }
            return true;
        }
        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }
    }


    public class AllowCyclePolicy : ShapeDecoratorCyclePolicy
    {
        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }
    }

    public class AbsorbCyclePolicy : ShapeDecoratorCyclePolicy
    {
        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return !allTypes.Contains(type);
        }
    }
    public abstract class ShapeDecorator : Shape
    {
        protected internal readonly List<Type> types = new ();
        protected internal readonly Shape shape;
        public ShapeDecorator(Shape shape)
        {
            this.shape = shape;
            if(shape is ShapeDecorator sd)
            {
                types.AddRange(sd.types);
            }
        }
    }

    public abstract class ShapeDecorator<TSelf, TCyclePolicy> : ShapeDecorator
        where TCyclePolicy : ShapeDecoratorCyclePolicy, new()
    {
        protected readonly TCyclePolicy policy = new();
        protected ShapeDecorator(Shape shape) : base(shape)
        {
            if(policy.TypeAdditionAllowed(typeof(TSelf), types))
                types.Add(typeof(TSelf));
        }
    }
    public class DetectingDecoratorCyclesDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var square = new Square(1.6f);
            Console.WriteLine(square.AsString());

            var coloredSquare1 = new ColoredShape(square, "red");
            Console.WriteLine(coloredSquare1.AsString());

            var coloredSquare2 = new ColoredShape(coloredSquare1, "green");
            Console.WriteLine(coloredSquare2.AsString());

        }
    }
}
