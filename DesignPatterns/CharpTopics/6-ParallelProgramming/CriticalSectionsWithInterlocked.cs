using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class CriticalSectionsWithInterlocked : IExecuteDemo
    {
        public class BanckAccout
        {

            private int balence;

            public int Balence
            {
                get { return balence; }
                private set { balence = value; }
            }

            public void Deposite(int amount)
            {
               Interlocked.Add(ref balence, amount);
            }

            public void Withdraw(int amount)
            {
                Interlocked.Add(ref balence, -amount);
            }
        }

        public void Execute()
        {
            var tasks = new List<Task>();

            var bankAccount = new BanckAccout();

            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
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
