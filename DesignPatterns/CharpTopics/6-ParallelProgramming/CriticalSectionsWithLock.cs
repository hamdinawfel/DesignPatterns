using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class CriticalSectionsWithLock : IExecuteDemo
    {
        public class BanckAccout
        {
            public object padlock = new object();
            public int Balence { get; private set; }

            public void Deposite(int amount)
            {
                lock (padlock)
                {
                    Balence += amount;
                }
            }

            public void Withdraw(int amount)
            {
                lock (padlock)
                {
                    Balence -= amount;
                }
            }
        }

        public void Execute()
        {
            var tasks = new List<Task>();

            var bankAccount = new BanckAccout();

            for(var i = 0; i <10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for(var i=0; i < 1000; i++)
                    {
                        bankAccount.Deposite(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bankAccount.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance : {bankAccount.Balence}");
        }
    }
}
