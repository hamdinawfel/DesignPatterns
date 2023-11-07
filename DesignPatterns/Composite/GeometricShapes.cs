using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
    public class GeometricObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color;

        private Lazy<List<GeometricObject>> children = new Lazy<List<GeometricObject>>();
        public List<GeometricObject> Children => children.Value;

        public void Print(StringBuilder sb, int depth)
        {
            sb.Append(new String('*', depth));
            sb.Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ");
            sb.AppendLine(Name);

            foreach(var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }

        public override string ToString()
        {
           var sb = new StringBuilder();
           Print(sb, 0);    
           return sb.ToString();
        }
    }

    public class Circle : GeometricObject
    {
        public override string Name => "Circle";
    }

    public class Square : GeometricObject
    {
        public override string Name => "Square";

    }


    public class GeometricShapes : IDisplayDemo
    {
        public void DisplayResult()
        {
            var drawing = new GeometricObject { Name = "My Drawing"};
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Green" });

            var group = new GeometricObject();
            group.Children.Add(new Square { Color = "Blue" });
            group.Children.Add(new Circle { Color = "Blue" });

            drawing.Children.Add(group);

            Console.WriteLine(drawing);
        }
    }
}
