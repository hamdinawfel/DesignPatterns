using DesignPatterns.Utils;
using System;
using System.Collections;
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

            // with array of objects
            var array = new object[] { 123, "C#", complexType };

            //array.Add

            foreach (var item in array)
            {
                Console.WriteLine(item.ToString());
            }

            // with ArrayList
            var arrayList = new ArrayList { 123, "C#", complexType };

            arrayList.Add(32);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
