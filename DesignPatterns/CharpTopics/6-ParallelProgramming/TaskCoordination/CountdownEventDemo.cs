

using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.TaskCoordination
{
    public class CountdownEventDemo : IExecuteDemo
    {
        private CountdownEvent countdownEvent = new CountdownEvent(5);
        private Random random = new Random();
        public void Execute()
        {
            for(int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entered task {Task.CurrentId}");
                    Thread.Sleep(random.Next(1000));
                    countdownEvent.Signal();
                    Console.WriteLine($"Exited task {Task.CurrentId}");
                });
            }

            var finalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Wait all other tasks to compeleted to enter in task $ {Task.CurrentId}");
                countdownEvent.Wait();
                Console.WriteLine("DINE !!!!");
            });

            finalTask.Wait();
        }
    }
}
