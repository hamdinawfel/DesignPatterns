namespace DesignPatterns.Utils
{
    public class Demo
    {
        private readonly IEnumerable<IDemo> _demos;
        private const string DEMO_SEPERATOR = "-----------------------------";
        public Demo(IEnumerable<IDemo> demos)
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
