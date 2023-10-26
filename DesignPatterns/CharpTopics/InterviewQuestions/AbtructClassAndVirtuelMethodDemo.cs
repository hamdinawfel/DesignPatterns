using DesignPatterns.Utils;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    /// <summary>
    /// An abstruct class has a default implementation for a method.
    /// The method's default implementation is needed in some class but not is some other class. How can you achieve it?
    /// </summary>
    public class AbtructClassAndVirtuelMethodDemo : IExecuteDemo
    {
        public abstract class AbstractClass
        {
            public virtual void AbstractClassMethod()
            {
                Console.WriteLine("Default implimentation");
            }
        }

        public class OtherClass1 : AbstractClass
        {

        }

        public class OtherClass2 : AbstractClass
        {
            public override void AbstractClassMethod()
            {
                Console.WriteLine("Default Other Class2 implimentation");
            }
        }

        public void Execute()
        {
            var c1 = new OtherClass1();
            c1.AbstractClassMethod();

            var c2 = new OtherClass2();
            c2.AbstractClassMethod();
        }
    }
}
