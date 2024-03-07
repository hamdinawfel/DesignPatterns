using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class WaitingTask : IExecuteDemo
    {
        public void Demo1()
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
            Demo1();
        }
    }
}
