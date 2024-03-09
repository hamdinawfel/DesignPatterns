using DesignPatterns.Utils;
using System.Collections.Concurrent;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ConcurrentCollections
{
    public class BlockingCollectionDemo : IExecuteDemo
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private BlockingCollection<int>  messages = new BlockingCollection<int>(new ConcurrentBag<int>(), 10);
        private Random random = new Random();

        private void RunProducer()
        {
            while (true)
            {
                Task.Factory.StartNew(() =>
                {
                    cts.Token.ThrowIfCancellationRequested();
                    int i = random.Next(100);
                    messages.Add(i);
                    Console.WriteLine($"+{i}");
                    Thread.Sleep(1000);
                });
            }
        }

        private void RunConsumer()
        {
            foreach(var message in messages.GetConsumingEnumerable())
            {
                cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine($"-{message}");
                Thread.Sleep(random.Next(1000));
            }
        }

        private void ProduceAndConsume()
        {
            var produce = Task.Factory.StartNew(RunProducer);
            var consume = Task.Factory.StartNew(RunConsumer);

            Task.WaitAll(new[] { produce, consume }, cts.Token);
        }

        public void Execute()
        {
            try
            {
                Task.Factory.StartNew(ProduceAndConsume);
            }
            catch(AggregateException aex)
            {
                aex.Handle(e => true);
            }

            Console.ReadKey();
            cts.Cancel();
        }
    }
}
