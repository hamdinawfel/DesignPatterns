using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    internal class CriticalSectionsWithMutex : IExecuteDemo
    {
        public class BanckAccout
        {
            public int Balence { get; private set; }

            public void Deposite(int amount)
            {
               Balence += amount;
            }

            public void Withdraw(int amount)
            {
               Balence -= amount;
            }
        }

        public void Execute()
        {
            var tasks = new List<Task>();

            var bankAccount = new BanckAccout();

            Mutex mutex = new Mutex();

            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {

                            bankAccount.Deposite(100);
                        }
                        finally
                        {
                            if (haveLock)
                                mutex.ReleaseMutex();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {

                            bankAccount.Withdraw(100);
                        }
                        finally
                        {
                            if (haveLock)
                                mutex.ReleaseMutex();
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance : {bankAccount.Balence}");
        }
    }
}
