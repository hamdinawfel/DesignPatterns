using DesignPatterns.Utils;

namespace DesignPatterns.Builder
{
    public enum CarType
    {
        Golf,
        Jib
    }

    public class Car
    {
        public CarType Type;
        public int WeelSize;

        public override string ToString()
        {
            return $"{nameof(Type)}:{Type}, {nameof(WeelSize)}:{WeelSize}";
        }
    }
    public interface ISpecifyCar
    {
        ISpecifyWeelSize OfType(CarType type);
    }

    public interface ISpecifyWeelSize
    {
        ICarBuilder WithWeelSize(int size);
    }

    public interface ICarBuilder
    {
        Car Build();
    }

    public class CarBuilder
    {
        private class Impl : ISpecifyCar, ISpecifyWeelSize, ICarBuilder
        {
            public Car car = new Car();

            public ISpecifyWeelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public ICarBuilder WithWeelSize(int size)
            {
                switch (car.Type)
                {
                    case CarType.Golf when size < 17 || size > 20:
                    case CarType.Jib when size < 15 || size > 17:
                        throw new ArgumentException($"wrong size of weel of type {car.Type}");
                }
                car.WeelSize = size;
                return this;
            }

            public Car Build()
            {
                return car;
            }
           
        }
        public static ISpecifyCar Create()
        {
            return new Impl();
        }
    }
    public class StepWiseBuilderDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var car = CarBuilder.Create()               
                                 .OfType(CarType.Golf)
                                 .WithWeelSize(17)
                                 .Build();

            Console.WriteLine(car.ToString());

        }
    }
}
