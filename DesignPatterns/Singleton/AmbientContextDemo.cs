
using DesignPatterns.Utils;
using System.Drawing;
using System.Text;

namespace DesignPatterns.Singleton
{
    public sealed class BuildingContext : IDisposable
    {
        public int WallHeight = 0;
        private static Stack<BuildingContext> stack
          = new Stack<BuildingContext>();

        static BuildingContext()
        {
            stack.Push(new BuildingContext(0));
        }

        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }

        public static BuildingContext Current => stack.Peek();

        public void Dispose()
        {
            if (stack.Count > 1)
                stack.Pop();
        }
    }
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
           X = x;
           Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)} : {X}, {nameof(Y)} : {Y}";
        }
    }

    public class Wall
    {
        public Point Start, End;
        public int Height;
        public Wall(Point start, Point end)
        {
            Start = start;
            End = end;
            Height = BuildingContext.Current.WallHeight;
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}, " +
                   $"{nameof(Height)}: {Height}";
        }
    }

    public class Building
    {
        public List<Wall> Walls = new List<Wall>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(Wall wall in Walls)
            {
                sb.AppendLine(wall.ToString());
            }
            return sb.ToString();   
        }
    }


    public class AmbientContextDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var house = new Building();

            // ground floor
            //var e = 0;
            house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
            house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

            // first floor
            //e = 3500;
            using (new BuildingContext(3500))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
            }

            // back to ground again
            house.Walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));

            Console.WriteLine(house);

        }
    }
}
