using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.Performance
{
    public class ReplaceDigits : IExecuteDemo
    {
        public static string ReplaceDigit(string sentence)

        {
            string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = new StringBuilder(sentence);
            for (var index = 0; index < sentence.Length; index++)
            {
                var c = sentence[index];
                if (Char.IsDigit(c))
                {
                    int digit = (int)Char.GetNumericValue(c);
                    result.Append(words[digit]);
                    if (index < sentence.Length - 1 && !Char.IsWhiteSpace(sentence[index + 1]))
                        result.Append(' ');
                }
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        public void Execute()
        {
            var sentence = "4 score and 7 years ago, 8 men had the same PIN code: 6571";
            var result = ReplaceDigit(sentence);
            Console.WriteLine(result);
        }
    }
}
