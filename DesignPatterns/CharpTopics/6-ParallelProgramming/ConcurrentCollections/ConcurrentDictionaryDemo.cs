using DesignPatterns.Utils;
using System.Collections.Concurrent;


namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ConcurrentCollections
{
    public class ConcurrentDictionaryDemo : IExecuteDemo
    {
        private ConcurrentDictionary<string, string> capitals = new ConcurrentDictionary<string, string>();
        private void AddCapitals()
        {
            bool success = capitals.TryAdd("Tunisia", "Tunis");
            var successExecutedTask = Task.CurrentId.HasValue ? "Task" : "Main";
            Console.WriteLine($"{successExecutedTask} - {success}");
        }
        public void Execute()
        {
            Task.Factory.StartNew(() =>
            {
                AddCapitals();
            });
            AddCapitals();

            //capitals["France"] = "Paris 1";
            //capitals.AddOrUpdate("France", "Paris", (k, old)=> old);
            Console.WriteLine(capitals["France"]);

            //capitals["Sweden"] = "Uppsala";

            var swedenCapital = capitals.GetOrAdd("Sweden", "Stockholm");

            Console.WriteLine($"The capital of sweeden is : {swedenCapital}");

            var toRemove = "France";
            string removed;
            bool isRemoved = capitals.TryRemove(toRemove, out removed); //TODO : why TryRemove throw an exception?
            if (isRemoved)
            {
                Console.WriteLine($"The value associated with key '{toRemove}' was removed: {removed}");
            }
            else
            {
                Console.WriteLine($"Key '{toRemove}' does not exist in the dictionary.");
            }

            foreach (var capital in capitals)
            {
                Console.WriteLine($"The capital of {capital.Key} is {capital.Value}");
            }
        }
    }
}
