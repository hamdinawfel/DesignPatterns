using DesignPatterns.Utils;
using System.Collections;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ParallelLinq
{
    public class AsParallelDemo : IExecuteDemo
    {
        public void Execute()
        {
            var count = 50;
            var items = Enumerable.Range(0, count).ToArray();

            var result = new int[count];

            //items.Select(i =>
            //{
            //    var cube = i * i * i;
            //    Console.WriteLine($"{cube} - Task : {Task.CurrentId}");
            //    result[i] = cube;
            //    return cube;
            //}).ToArray();

            //var cubes = items.Select(i => i * i * i);

            items.AsParallel().ForAll(i =>
            {
                var cube = i * i * i;
                Console.WriteLine($"{cube} - Task : {Task.CurrentId}");
                result[i] = cube;
            });

            Console.WriteLine("=====================================");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

           Console.WriteLine("=====================================");
            var cubes = items.AsParallel().AsOrdered().Select(i => i * i * i);

            foreach(var cube in cubes)
            {
                Console.WriteLine($"{cube}");
            }
        }
    }
}
