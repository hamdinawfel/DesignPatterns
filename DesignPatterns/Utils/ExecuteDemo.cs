using DesignPatterns.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Utils
{
    public class ExecuteDemo
    {
        private readonly IExecuteDemo _demo;
        public ExecuteDemo(IExecuteDemo demo)
        {
            _demo = demo;
        }

        public void Execute()
        {
            Console.WriteLine(_demo.GetType().Name);
            _demo.Execute();    
        }
        
    }
}
