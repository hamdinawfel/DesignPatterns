using DesignPatterns.Utils;
using System.Collections.Concurrent;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ConcurrentCollections
{
    public class ConcurrentBagDemo : IExecuteDemo
    {
        public void Execute()
        {
            // NO ORDERED
           var bag = new ConcurrentBag<int>();
           
            var tasks = new List<Task>();

            for(int i = 0; i < 10; i++)
            {
                var i1 = i;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    bag.Add(i1);
                    Console.WriteLine($"- {Task.CurrentId} added this value : {i1}");

                    int result;

                    if (bag.TryPeek(out result))
                    {
                        Console.WriteLine($"- {Task.CurrentId} peeked this value : {result}");
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
