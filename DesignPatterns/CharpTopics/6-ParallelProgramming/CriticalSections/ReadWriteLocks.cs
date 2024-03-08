using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class ReadWriteLocks : IExecuteDemo
    {
        public void Execute()
        {
            ReaderWriterLockSlim padlock = new ReaderWriterLockSlim();
            var tasks = new List<Task>();

            var x = 0;

            for(int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    padlock.EnterReadLock();

                    Console.WriteLine($"Enter Read Lock x : {x}");

                    Thread.Sleep(1000);

                    padlock.ExitReadLock();

                    Console.WriteLine($"Exit Read Lock x : {x}");
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException aex)
            {
                aex.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }

            while (true)
            {
                var input = Console.ReadLine();
                int.TryParse(input.ToString(), out int newValue);
                padlock.EnterWriteLock();
                x = newValue;   
                Console.WriteLine($"Enter Write Lock {x}");
                padlock.ExitWriteLock();
                Console.WriteLine($"Exit Write Lock x : {x}");
            }
        }
    }
}
