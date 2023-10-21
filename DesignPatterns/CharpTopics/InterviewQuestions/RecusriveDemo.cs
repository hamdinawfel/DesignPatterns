using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.InterviewQuestions
{
    public static class FileFinder
    {
        public static void FindFiles(string path, List<string> files)
        {
            foreach(var fileName in Directory.GetFiles(path))
            {
                files.Add(fileName);
            }
            foreach(var subDirectory in Directory.GetDirectories(path))
            {
                FindFiles(subDirectory, files);
            }
        }
    }

    public class RecusriveDemo : IExecuteDemo
    {
        public double FactorialWithRecusrsive(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            var factorial = number * FactorialWithRecusrsive(number - 1);
            return factorial;
        }
        public double Factorial(int number)
        {
            if(number == 0)
            {
                return 1;
            }

            double factorial = 1;
            for(int i = number;  i >= 1; i--)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
        public void Execute()
        {
            //Console.WriteLine("Enter a number");
            //int number = Convert.ToInt32(Console.ReadLine());

            //double factorial1 = Factorial(number);
            //double factorial2 = FactorialWithRecusrsive(number);

            //Console.WriteLine($"The factorial of {number} calculated without recursive is : {factorial1}");
            //Console.WriteLine($"The factorial of {number} calculated with recursive is : {factorial2}");

            Console.WriteLine("Enter a file folder path");
            string path = Console.ReadLine();

            var myFiles = new List<string>();   

            FileFinder.FindFiles(path, myFiles);
           
            foreach(var file in myFiles)
            {
                Console.WriteLine(file);
            }
        }
    }
}
