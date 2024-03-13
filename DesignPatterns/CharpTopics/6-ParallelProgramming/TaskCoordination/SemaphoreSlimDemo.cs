
using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.TaskCoordination
{
    public class SemaphoreSlimDemo : IExecuteDemo
    {
        public void Execute()
        {
            var semaphore = new SemaphoreSlim(2, 10);

            for (int i = 0; i < 20; ++i)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}.");
                    semaphore.Wait(); // ReleaseCount--
                    Console.WriteLine($"Processing task {Task.CurrentId}.");
                });
            }

            while (semaphore.CurrentCount <= 2)
            {
                Console.WriteLine($"Semaphore count: {semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release(2); // ReleaseCount += n
            }
        }
    }
}
