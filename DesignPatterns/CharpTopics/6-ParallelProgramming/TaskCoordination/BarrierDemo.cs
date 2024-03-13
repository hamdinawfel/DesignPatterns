using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.TaskCoordination
{
    public class BarrierDemo : IExecuteDemo
    {
        private Barrier barrier = new Barrier(2, b =>
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} is finished");
        });

        private void Operation1()
        {
            Console.WriteLine("-First Phase of Operation1");
            Thread.Sleep(1000);
            barrier.SignalAndWait();
            Console.WriteLine("-Second Phase of Operation1");
            barrier.SignalAndWait();
            Console.WriteLine("-Third Phase of Operation1");
        }

        private void Operation2()
        {
            Console.WriteLine("-First Phase of Operation2");
            barrier.SignalAndWait();
            Console.WriteLine("-Second Phase of Operation2");
            Thread.Sleep(1000);
            barrier.SignalAndWait();
            Console.WriteLine("-Third Phase of Operation2");
        }

        public void Execute()
        {
            var opreration1 = Task.Factory.StartNew(Operation1);
            var opreration2 = Task.Factory.StartNew(Operation2);

            var task = Task.Factory.ContinueWhenAll(new[] { opreration1, opreration2 }, tasks =>
            {
                Console.WriteLine("All operation done");
            });

            task.Wait();    
        }
    }
}
