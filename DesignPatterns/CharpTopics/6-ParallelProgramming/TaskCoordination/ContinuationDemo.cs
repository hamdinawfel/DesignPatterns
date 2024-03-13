using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.TaskCoordination
{
    public class ContinuationDemo : IExecuteDemo
    {
        private void Demo3()
        {
            var task1 = Task.Factory.StartNew(() => "Task 1");
            var task2 = Task.Factory.StartNew(() => "Task 2");

            var task3 = Task.Factory.ContinueWhenAny(new[] { task1, task2 }, task =>
            {
                Console.WriteLine($"- {task.Result}");
                Console.WriteLine("Any task done");
            });

            task3.Wait();
        }

        private void Demo2()
        {
            var task1 = Task.Factory.StartNew(() => "Task 1");
            var task2 = Task.Factory.StartNew(() => "Task 2");

            var task3 = Task.Factory.ContinueWhenAll(new[] { task2, task1 }, tasks =>
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"- {task.Result}");
                }
                Console.WriteLine("All task done");
            });

            task3.Wait();
        }

        private void Demo1()
        {
            var task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task 1 running now");
            });

            var task2 = task1.ContinueWith(t =>
            {
                Console.WriteLine($"Task {t.Id} is completed, and Task 2 is running");
            });

            task2.Wait();
        }

        public void Execute()
        {
            //Demo1();
            //Demo2();
            Demo3();
        }
    }
}
