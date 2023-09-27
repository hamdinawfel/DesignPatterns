using DesignPatterns.Utils;
using System.Reflection;

namespace DesignPatterns.Singleton
{
    public interface ISingletonDatabase
    {
        string GetPopulation(string capital);
    }
    public class SingletonDatabase : ISingletonDatabase
    {
        private readonly Dictionary<string, int> populations = new Dictionary<string, int>();
        
        private SingletonDatabase()
        {
            Console.WriteLine("Database initialization");

            var assembly = typeof(SingletonDatabase).Assembly;
            var filePath = Path.Combine(Path.GetDirectoryName(assembly.Location), "Singleton", "capitals.txt");

            var content = File.ReadAllLines(filePath);
            var currentCity = String.Empty;

            foreach(var line in content)
            {
                var isNumber = int.TryParse(line, out int population);
                if (isNumber && !string.IsNullOrEmpty(currentCity))
                {
                    populations[currentCity] = population;
                    currentCity = String.Empty;
                }
                else
                {
                    currentCity = line.Trim();
                }
            }
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;

        public string GetPopulation(string capital)
        {
            return $"the Population in {capital} is : {populations[capital]}";
        }
    }

    public class SingletonDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var db = SingletonDatabase.Instance;
            var capital = "New York";
            var population =  db.GetPopulation(capital);
            Console.WriteLine(population);
        }
    }
}
