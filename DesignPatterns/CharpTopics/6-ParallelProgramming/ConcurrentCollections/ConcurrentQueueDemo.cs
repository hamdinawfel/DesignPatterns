using DesignPatterns.Utils;
using System.Collections.Concurrent;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ConcurrentCollections
{
    public class ConcurrentQueueDemo : IExecuteDemo
    {
        public void Execute()
        {
            //FIFO
            var q = new ConcurrentQueue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            int result;
            if (q.TryDequeue(out result))
            {
                Console.WriteLine($"removed :  {result}");
            }

            if (q.TryPeek(out result))
            {
                Console.WriteLine($"First item in queue :  {result}");
            }

            Console.WriteLine("queue Existed items : ");
            foreach(var item in q)
            {
                Console.WriteLine(item);
            }
        }
    }
}
