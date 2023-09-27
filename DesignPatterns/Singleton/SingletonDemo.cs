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

        private static SingletonDatabase instance = new SingletonDatabase();
        public static SingletonDatabase Instance = instance;

        public string GetPopulation(string capital)
        {
            return $"the Population in {capital} is : {populations[capital]}";
        }
    }

    public class SingletonDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var population =  SingletonDatabase.Instance.GetPopulation("New York");
            Console.WriteLine(population);
        }
    }
}
