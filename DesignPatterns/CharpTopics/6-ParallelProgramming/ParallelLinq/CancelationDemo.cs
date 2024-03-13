using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ParallelLinq
{
    public class CancelationDemo : IExecuteDemo
    {
        public void Execute()
        {
            var items = ParallelEnumerable.Range(1, 10);

            var cte = new CancellationTokenSource();

            var results = items.WithCancellation(cte.Token).Select(x  =>{
                var log = Math.Log10(x);

                //if (log > 1)
                //{
                //    throw new InvalidOperationException();
                //}

                Console.WriteLine($"{log} - Task : {Task.CurrentId}");
                return log;
            });

            try
            {
                foreach (var item in results)
                {
                    Console.WriteLine(item);
                    cte.Cancel();
                    if (item > 1)
                    {
                        cte.Cancel();
                    }
                }
            }
            catch(AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
