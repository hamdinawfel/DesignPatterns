using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._4_ConversionOperator
{

    public class UserId
    {
        public Guid Value { get; }
        public UserId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(UserId userId) => userId.Value;
        public static implicit operator UserId(Guid id) => new UserId(id);
       
    }

    public readonly struct Digit
    {
        private readonly byte digit;

        public Digit(byte digit)
        {
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
            }
            this.digit = digit;
        }

        public static implicit operator byte(Digit d) => d.digit;
        public static explicit operator Digit(byte b) => new Digit(b);

        public override string ToString() => $"{digit}";
    }
    public class ConversionOperatorDemo : IExecuteDemo
    {
        public void Execute()
        {
            //========================
            var d = new Digit(7);
            byte number = d;
            Console.WriteLine(number);  // output: 7

            Digit digit = (Digit)number;
            Console.WriteLine(digit);  // output: 7

            //========================
            var id = Guid.NewGuid();

            var userId = new UserId(id);    

            Guid id2 = new UserId(id);

            UserId userId2 = id;

        }
    }
}
