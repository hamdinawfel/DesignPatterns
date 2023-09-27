
using DesignPatterns.Utils;

namespace DesignPatterns.Singleton
{
    public sealed class PerThreadSingleton
    {
        //Singleton per thred with ThreadLocal<T>

        private static ThreadLocal<PerThreadSingleton> ThreadLocalInstance =
            new ThreadLocal<PerThreadSingleton>(() => new PerThreadSingleton());

        public static PerThreadSingleton Instance => ThreadLocalInstance.Value;

        //Singleton with Lazy<T>
        private static Lazy<PerThreadSingleton> lazyInstance = new Lazy<PerThreadSingleton>(() => new PerThreadSingleton());
        public static PerThreadSingleton LazyInstance => lazyInstance.Value;


        public int Id;
        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

    }

    public class PerThreadSingletonDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("T1 : " + PerThreadSingleton.Instance.Id);
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("T2 : " + PerThreadSingleton.Instance.Id);
                Console.WriteLine("T2 : " + PerThreadSingleton.Instance.Id);
            });

            Task.WaitAll(t1,t2);


            // Outpout  With ThreadLocal<PerThreadSingleton>  (see 1)
            //T1: 6
            //T2: 7
            //T2: 7

            // Outpout  With Lazy<T>  (see 2)
            //T1: 6
            //T2: 6
            //T2: 6
        }
    }
}
