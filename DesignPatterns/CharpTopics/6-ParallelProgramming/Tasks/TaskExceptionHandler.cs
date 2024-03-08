using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class TaskExceptionHandler : IExecuteDemo
    {

        private void Demo2()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t1 = Task.Factory.StartNew(() =>
            {
                throw new OperationCanceledException("error from t1") { Source = "t1" };
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("error from t2") { Source = "t2" };
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException aex)
            {
                aex.Handle(e =>
                {
                    if(e is OperationCanceledException)
                    {
                        Console.WriteLine($"Exception handled : {e.GetType()} - {e.Source} - {e.Message}");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
        }

        private void Demo1()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t1 = Task.Factory.StartNew(() =>
            {
                throw new OperationCanceledException("error from t1") { Source = "t1" };
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("error from t2") { Source = "t2" };
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch(AggregateException ex)
            {
                foreach(Exception iex in ex.InnerExceptions)
                {
                    Console.WriteLine($"{iex.GetType()} - {iex.Source} - {iex.Message}");
                }
            }
        }

        public void Execute()
        {
            //Demo1();

            try
            {
                Demo2();
            }
            catch (AggregateException ex)
            {
                foreach (Exception iex in ex.InnerExceptions)
                {
                    Console.WriteLine($"Exception throwed in else bloc is also handled : {iex.GetType()} - {iex.Source} - {iex.Message}");
                }
            }
        }
    }
}
