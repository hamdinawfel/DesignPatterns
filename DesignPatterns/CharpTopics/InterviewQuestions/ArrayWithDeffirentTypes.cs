using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    public class ComplexType
    {
        public string type;

        public ComplexType(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return $"{type}";
        }
    }

    public class ArrayWithDeffirentTypes : IExecuteDemo
    {
        public void Execute()
        {
            var complexType = new ComplexType("Class");    
            var myarr = new object[] { 123, "C#", complexType };

            foreach (var item in myarr)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
