using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class CreateAndStartTasks : IExecuteDemo
    {
        private void Write(char c)
        {
            int i = 1000;
            while(i --> 0)
            {
                Console.Write(c);
            }
        }

        private void Write(object o)
        {

            for(int j = 0; j < 1000; j++)
            {
                Console.WriteLine($"{j} - {o}");
            }
        }

        private int GetLength(object o)
        {
            Console.WriteLine($"Task {Task.CurrentId} length of {o} is :");
            return o.ToString().Length;
        }
        public void Execute()
        {
            // DEMO 1

            //Task.Factory.StartNew(() => Write('a'));
            //var task = new Task(() => Write('b'));
            //task.Start();
            //Write('c');

            // DEMO 2

            //var task = new Task(Write, "Hello");
            //task.Start();
            ////task.Wait();

            //Task.Factory
            //    .StartNew(Write, "World ");
            //    //.Wait();

            // DEMO 3

            var text1 = "Hello";
            var text2 = "World";

            var task1 = new Task<int>(GetLength, text1);
            task1.Start();
            var task2 = Task.Factory.StartNew<int>(GetLength, text2);

            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);
        }
    }
}
