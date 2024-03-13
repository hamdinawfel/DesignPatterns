using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.Performance
{
    public class PreventBoxingAndUnbosing : IExecuteDemo
    {
        public static Dictionary<char, int> GetCharacterCount(string name)
        {
            var result = new Dictionary<char, int>();
            foreach (char c in name.ToLower())
            {
                if(char.IsWhiteSpace(c))
                    continue;

                if (result.ContainsKey(c))
                {
                    result[c]++;
                }
                else
                {
                    result[c] = 1;
                }
            }
            return result;
        }

        public void Execute()
        {
            var name = "John Doe";
            var result = GetCharacterCount(name);

            foreach (var pair in result)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }
        }
    }
}
