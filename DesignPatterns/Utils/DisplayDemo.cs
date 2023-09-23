namespace DesignPatterns.Utils
{
    public class DisplayDemo
    {
        private readonly IEnumerable<IDisplayDemo> _demos;
        private const string DEMO_SEPERATOR = "-----------------------------";
        public DisplayDemo(IEnumerable<IDisplayDemo> demos)
        {
            _demos = demos;
        }

        public void Display()
        {
            foreach (var demo in _demos)
            {
                Console.WriteLine(DEMO_SEPERATOR);
                Console.WriteLine(demo.GetType().Name);
                demo.DisplayResult();
                Console.WriteLine(DEMO_SEPERATOR);
            }
        }
    }
}
