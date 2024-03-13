using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming.ParallelLoops
{
    public class LoopsDemo : IExecuteDemo
    {
        public void Execute()
        {
            var a = new Action(() => { Console.WriteLine($"First : {Task.CurrentId}"); });
            var b = new Action(() => { Console.WriteLine($"Second : {Task.CurrentId}"); });
            var c = new Action(() => { Console.WriteLine($"Third : {Task.CurrentId}"); });

            Parallel.Invoke(a, b, c);

            Parallel.For(1, 11, i =>
            {
                Console.WriteLine($"{i*i}");
            });

            var words = new string[] { "Hello", "Tech", "Dev" };

            Parallel.ForEach(words, word =>
            {
                Console.WriteLine($"{word} Length : {word.Length} Task : {Task.CurrentId}");
            });
        }
    }
}
