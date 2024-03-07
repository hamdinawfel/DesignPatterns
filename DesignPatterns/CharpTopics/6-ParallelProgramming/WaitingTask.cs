using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class WaitingTask : IExecuteDemo
    {
        private void Demo2()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;  

            var task1 = new Task(() =>
            {
                Console.WriteLine("Task 1 will take 5 seconds");
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{i} - Task 1");
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Task 1 done !");
            },token);

            task1.Start();

            var task2 = new Task(() =>
            {
                Console.WriteLine("Task 2 will take 3 seconds");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{i} - Task 2");
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Task 2 done !");
            }, token);

            
            task2.Start();

            //Task.WaitAll(task1, task2);
            //Task.WaitAny(task1, task2);
            //Task.WaitAll(new[] { task1, task2 } );
            Task.WaitAll(new[] { task1, task2 }, 4000 );

            Console.WriteLine("Tasks status");
            Console.WriteLine($"task 1 status : {task1.Status}");
            Console.WriteLine($"task 2 status : {task2.Status}");

            Console.ReadLine();
            cts.Cancel();
        }

        private void Demo1()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var task = new Task(() =>
            {
                Console.WriteLine("Press any key to disarmed Bomb, you have just 5 second");

                var time = 5;
                while(time > 0)
                {
                    Console.WriteLine($"{time} s");
                    Thread.Sleep(1000);
                    time--;
                }

                bool isCanceled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(isCanceled ? "Bomb disarmed" : "BOOMB !!!!");
            }, token);

            task.Start();

            Console.ReadKey();
            cts.Cancel();

        }
        public void Execute()
        {
            //Demo1();
            Demo2();
        }
    }
}
