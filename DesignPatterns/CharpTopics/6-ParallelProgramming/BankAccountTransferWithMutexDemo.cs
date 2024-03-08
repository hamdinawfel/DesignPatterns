using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class BankAccountTransferWithMutexDemo : IExecuteDemo
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

            public void Transfer(BanckAccout banckAccout, int amout)
            {
                Balence -= amout;
                banckAccout.Balence += amout;
            }
        }

        public void Execute()
        {
            var tasks = new List<Task>();

            var bankAccount1 = new BanckAccout();
            var bankAccount2 = new BanckAccout();

            Mutex mutex1 = new Mutex();
            Mutex mutex2 = new Mutex();

            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool haveLock = mutex1.WaitOne();
                        try
                        {

                            bankAccount1.Deposite(1);
                        }
                        finally
                        {
                            if (haveLock)
                                mutex1.ReleaseMutex();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool haveLock = mutex2.WaitOne();
                        try
                        {

                            bankAccount2.Deposite(1);
                        }
                        finally
                        {
                            if (haveLock)
                                mutex2.ReleaseMutex();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        bool haveLock = WaitHandle.WaitAll(new[] { mutex1, mutex2 });
                        try
                        {
                            bankAccount1.Transfer(bankAccount2, 1);
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex1.ReleaseMutex();
                                mutex2.ReleaseMutex();
                            }
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final BA 1 balance  : {bankAccount1.Balence}");
            Console.WriteLine($"Final BA 2 balance : {bankAccount2.Balence}");
        }
    }
}
