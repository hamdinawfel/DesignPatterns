using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.TaskCoordination
{
    public class ResetEventSlimDemo : IExecuteDemo
    {
        private void Demo1()
        {
            var evt = new ManualResetEventSlim();

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Prepare water");
                evt.Set();
            });

            var tea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting water");
                evt.Wait();
                Console.WriteLine("Tea done !!!");
            });

            tea.Wait();
        }
        public void Execute()
        {
            
            Demo1();
        }
    }
}
