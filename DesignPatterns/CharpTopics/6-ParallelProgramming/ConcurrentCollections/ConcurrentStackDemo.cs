using DesignPatterns.Utils;
using System.Collections.Concurrent;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ConcurrentCollections
{
    public class ConcurrentStackDemo : IExecuteDemo
    {
        public void Execute()
        {
            //LIFO
            var stack = new ConcurrentStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            int result;
            if (stack.TryPeek(out result))
            {
                Console.WriteLine($"Pekked item :  {result}");
            }
            Console.WriteLine("Stack items: " + string.Join(", ", stack));

            if (stack.TryPop(out result))
            {
                Console.WriteLine($"Popeed :  {result}");
            }

            Console.WriteLine("Stack items: " + string.Join(", ", stack));

            var items = new int[2];

            if (stack.TryPopRange(items, 0, 2) > 0)
            {
                Console.WriteLine("Stack after TryPopRange : " + string.Join(", ", stack));
                Console.WriteLine("removedform stack and inserted in items: " + string.Join(", ", items));
            }

        }
    }
}
