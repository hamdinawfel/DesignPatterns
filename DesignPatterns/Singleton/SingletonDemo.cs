using DesignPatterns.Utils;
using NUnit.Framework;
using System.Reflection;

namespace DesignPatterns.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string capital);
    }
    public class SingletonDatabase : IDatabase
    {
        private readonly Dictionary<string, int> populations = new Dictionary<string, int>();

        private static int instanceCount;
        public static int InstanceCount => instanceCount;
        private SingletonDatabase()
        {

            Console.WriteLine("Database initialization");

            instanceCount++;
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

        public int GetPopulation(string capital)
        {
            return populations[capital];
        }

       
    }

    public class TotalPopulationFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }
            return result;
        }
    }

    public class ConfigurablePopulationFinder
    {
        private readonly IDatabase database;
        public ConfigurablePopulationFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }
            return result;
        }
    }


    public class OrdirnaryDatabase : IDatabase
    {
        private readonly Dictionary<string, int> populations;
        public OrdirnaryDatabase()
        {
            Console.WriteLine("Database initialization");

            var assembly = typeof(SingletonDatabase).Assembly;
            var filePath = Path.Combine(Path.GetDirectoryName(assembly.Location), "Singleton", "capitals.txt");

            var content = File.ReadAllLines(filePath);
            var currentCity = String.Empty;

            foreach (var line in content)
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

        public int GetPopulation(string capital)
        {
            return populations[capital];
        }
    }
    public class SingletonDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var db = SingletonDatabase.Instance;
            var capital = "New York";
            var population =  db.GetPopulation(capital);
            Console.WriteLine($"The population in this city {capital} is : {population}");
        }
    }
}
