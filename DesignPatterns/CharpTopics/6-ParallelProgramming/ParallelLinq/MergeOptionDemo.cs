using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ParallelLinq
{
    public class MergeOptionDemo : IExecuteDemo
    {
        public void Execute()
        {
            var items = Enumerable.Range(1, 20).ToArray();

            var results = items
                           .AsParallel()
                           .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                           .Select(x =>
            {
                var log = Math.Log10(x);
                Console.WriteLine($"Produce : {log}");
                return log;
            });

            foreach(var item in results)
            {
                Console.WriteLine($"Consume : {item}");
            }
        }
    }
}
