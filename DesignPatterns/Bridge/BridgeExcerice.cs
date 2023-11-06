using DesignPatterns.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public class BridgeExcerice : IDisplayDemo
    {
        public interface IRenderer
        {
            string WhatToRenderAs { get; }
        }

        public abstract class Shape
        {
            private IRenderer rendering;

            protected Shape(IRenderer rendering)
            {
                this.rendering = rendering;
            }

            public string Name { get; set; }

            public override string ToString()
            {
                return $"Drawing {Name} as {rendering.WhatToRenderAs}";
            }
        }

        public class Triangle : Shape
        {
            public Triangle(IRenderer strategy) : base(strategy)
            {
                Name = "Triangle";
            }
        }

        public class Square : Shape
        {
            public Square(IRenderer rendering) : base(rendering)
            {
                Name = "Square";
            }
        }

        public class RasterRenderer : IRenderer
        {
            public string WhatToRenderAs
            {
                get { return "pixels"; }
            }
        }

        public class VectorRenderer : IRenderer
        {
            public string WhatToRenderAs
            {
                get { return "lines"; }
            }
        }

        public void DisplayResult()
        {
            var result = new Square(new VectorRenderer()).ToString();
            Console.WriteLine($"Expected : Drawing Square as lines :  Current : {result}");
        }
    }
}
