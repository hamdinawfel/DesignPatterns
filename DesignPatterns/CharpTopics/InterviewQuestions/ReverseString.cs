using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    public class ReverseString : IExecuteDemo
    {
        public void Execute()
        {
            Console.WriteLine("Enter a sentence to reverse each word in it");
            var input = Console.ReadLine();

            var words = input.Split(" ");

            foreach(var word in words)
            {
                var aux = string.Empty;

                for(int i = word.Length - 1; i >= 0; i--)
                {
                    aux = aux + word[i];
                }
                words[Array.IndexOf(words,word)] = aux;

            }

            var output = string.Join(" ", words);
            Console.WriteLine(output);
        }
    }
}
