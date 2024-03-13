using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ParallelLinq
{
    internal class CustomAggregationDemo : IExecuteDemo
    {
        public void Execute()
        {
            var sum1 = Enumerable.Range(1, 1000).Sum();

            var sum2 = Enumerable.Range(1, 1000).Aggregate(0, (x, acc) => acc += x);

            var sum3 = ParallelEnumerable.Range(1, 1000).
                Aggregate(
                0,
                (partialSum, x) => partialSum += x,
                (totalSum, partialSum) => totalSum += partialSum,
                x => x);

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
        }
    }
}
