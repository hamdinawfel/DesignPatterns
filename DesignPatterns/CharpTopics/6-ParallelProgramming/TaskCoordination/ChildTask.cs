using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.TaskCoordination
{
    public class ChildTask : IExecuteDemo
    { 
        private void Demo1()
        {
            var parentTask = new Task(() =>
            {
               
                var childTask = new Task(() =>
                {
                    Console.WriteLine("- Child task start");
                    Thread.Sleep(1000);
                    Console.WriteLine($"- Child task complete");
                    throw new Exception();
                }, TaskCreationOptions.AttachedToParent);
                
                childTask.Start();

                var completionHandler = childTask.ContinueWith(t =>
                {
                    Console.WriteLine($" DONE : {t.Id} - {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

                var failderHandler = childTask.ContinueWith(t =>
                {
                    Console.WriteLine($" Failed : {t.Id} - {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);

            });

            parentTask.Start();

            try
            {
                parentTask.Wait();
            }
            catch(AggregateException aex)
            {
                aex.Handle(e => true);
            }
        }
        public void Execute()
        {
            Demo1();
        }
    }
}
