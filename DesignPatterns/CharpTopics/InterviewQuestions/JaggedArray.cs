using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    public class JaggedArray : IExecuteDemo
    {
        public void Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("public class Program");
            sb.AppendLine("{");

            var fields = new string[][] { new string [] { "string", "Name"}, new [] { "int", "Age" } };

            foreach(var field in fields)
            {
                sb.AppendLine($"{new string(' ', 4)}{field[0]}{new string(' ', 1)}{field[1]};");
            }

            var thirdProps = new string[3];

            thirdProps[0] = "double";
            thirdProps[1] = "Salary";
            thirdProps[2] = " = 4300.60";

            var fields3 = new string[1][]; 

            fields3[0] = new string[3]; 

            fields3[0][0] = thirdProps[0];
            fields3[0][1] = thirdProps[1];
            fields3[0][2] = thirdProps[2];

            foreach (var field in fields3)
            {
                sb.AppendLine($"{new string(' ', 4)}{field[0]}{new string(' ', 1)}{field[1]}{field[2]};");
            }
            sb.AppendLine("}");

            Console.WriteLine(sb);
        }
    }
}
