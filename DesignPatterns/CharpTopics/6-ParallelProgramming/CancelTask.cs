using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class CancelTask : IExecuteDemo
    {
        public void Demo3()
        { 
            var planned =new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, preventative.Token, emergency.Token);
            var task = new Task(() =>
            {
                var i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\n");
                    Thread.Sleep(500);
                }
            }, paranoid.Token);
            task.Start();

            Console.ReadKey();
            emergency.Cancel();

        }
        public void Demo2()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            // handle notification when a task is canceled : Option 1
            token.Register(() =>
            {
                Console.WriteLine("NOTIFICATION 1 : Cancelation has been requested!");
            });

            var i = 0;
            var task = new Task(() =>
            {
                while (true)
                {
                   token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\n");
                }
            }, token);
            task.Start();

            // handle notification when a task is canceled : Option 2 with WailHandle
            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("NOTIFICATION 2: Wait handler released , Cancelation has been requested!");
            });

            Console.ReadKey();
            cts.Cancel();
        }
        public void Demo1()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var i = 0;
            var task = new Task(() =>
            {
                while (true)
                {
                    // option 1

                    if(token.IsCancellationRequested)
                        break;
                    // option 2

                    //if (token.IsCancellationRequested)
                    //    throw new OperationCanceledException();

                    else
                        Console.WriteLine($"{i++}\n");
                }
            },token);
            task.Start();

            Console.ReadKey();
            cts.Cancel();

        }
        public void Execute()
        {
            //Demo1();
            //Demo2();
            Demo3();
        }
    }
}
