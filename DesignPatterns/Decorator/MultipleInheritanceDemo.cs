using DesignPatterns.Utils;

namespace DesignPatterns.Decorator
{
    public interface IBird
    {
        int Wieght { get; set; }
        void Fly();
    }
    public class Bird
    {
        public int Wieght { get; set; }
        public void Fly()
        {
            Console.WriteLine($"Fly in the sky, {Wieght}");
        }
    }

    public interface ILizard
    {
        int Wieght { get; set; }
        void Crawl();
    }
    public class Lizard
    {
        public int Wieght { get; set; }
        public void Crawl()
        {
            Console.WriteLine($"Crawl in the disert with wieght {Wieght}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;
        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }

       public int Wieght
       { 
            get { return weight; }   
            set
            { 
                weight = value;
                bird.Wieght = value;
                lizard.Wieght = value;
            }
       }
    }

    public class MultipleInheritanceDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var dragon = new Dragon();
            dragon.Wieght = 5;
            dragon.Fly();
            dragon.Crawl();
        }
    }
}
