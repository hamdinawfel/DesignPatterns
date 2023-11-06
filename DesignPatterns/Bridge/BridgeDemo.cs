using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RastorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle with radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Drow();
        public abstract void Resize(float factor);
    }
    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Drow()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
    public class BridgeDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var renderer = new RastorRenderer();
            var c = new Circle(renderer, 5);
            c.Drow();
            c.Resize(2);
            c.Drow();
        }
    }
}
