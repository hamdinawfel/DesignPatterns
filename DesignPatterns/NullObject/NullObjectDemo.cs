using Autofac;
using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.NullObject
{
    public interface ILog
    {
        void Log(string message);
        void Warn(string message);
    }

    public class ConsoleLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class BankAccount
    {
        private ILog _log;
        private int _balence;

        public BankAccount(ILog log)
        {
            _log = log;
        }
        public void Deposite(int ammount)
        {
            _balence += ammount;
            _log.Log($"diposed ammount {ammount} , Now the balence is {_balence}");
        }
    }

    public class NullLog : ILog
    {
        public void Log(string message)
        {
        }

        public void Warn(string message)
        {
        }
    }
    public class NullObjectDemo : IDisplayDemo
    {
        public void DisplayResult()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BankAccount>();

            // NullLog is created to handle null object in DI for Null Object pattern demo

            //builder.RegisterType<NullLog>().As<ILog>();
            builder.RegisterType<ConsoleLog>().As<ILog>();

            using (var c = builder.Build())
            {
                var ba = c.Resolve<BankAccount>();
                ba.Deposite(100);
            }

        }
    }
}
