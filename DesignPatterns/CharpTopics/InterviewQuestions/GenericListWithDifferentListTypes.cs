using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    public class GenericListWithDifferentListTypes : IExecuteDemo
    {
        public void Execute()
        {

            var list = new List<List<object>>();

            var l1 = new List<object>();

            l1.Add("Id_1");
            l1.Add(1000);

            var l2 = new List<object>();

            l2.Add(true);
            l2.Add(0.9f);

            list.Add(l1);
            list.Add(l2);

            foreach(var l in list)
            {
                foreach(var e in l)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
