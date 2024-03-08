using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    internal class CriticalSectionsWithSpinlock : IExecuteDemo
    {
        public class BanckAccout
        {
            public object padlock = new object();
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

            SpinLock spinLock = new SpinLock();

            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool isLockTaken = false;
                        try
                        {
                            spinLock.Enter(ref isLockTaken);
                            bankAccount.Deposite(100);
                        }
                        finally
                        {
                            if(isLockTaken)
                               spinLock.Exit();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool isLockTaken = false;
                        try
                        {
                            spinLock.Enter(ref isLockTaken);
                            bankAccount.Withdraw(100);
                        }
                        finally
                        {
                            if (isLockTaken)
                                spinLock.Exit();
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance : {bankAccount.Balence}");
        }
    }
}
