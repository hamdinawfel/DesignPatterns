using DesignPatterns.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    /// <summary>
    /// What heppen if the finaly blaock throw an exception?
    /// 1 - The exception propageted up and it should be handled in the hignt level,
    /// if not handled the application will crash
    /// 2 - The finally block exception stops at the point where the exception is thrown
    /// 3 - If the finally block is being executed after an excêption has occured in the try block
    /// 3 -- a :and if that exception is not handled
    /// and it the finally block throws an exception
    /// Then the original exception that occurred in the try black is lost
    /// </summary>
    public class ExceptionDemo : IExecuteDemo
    {
        public void Hello()
        {
            try
            {

            }
            catch
            {

            }
            finally
            {
                Console.WriteLine("This line will be executed");
                var mumber = Convert.ToInt32("NO_NUMBER");
                Console.WriteLine("This line will be not executed");
                //2- because the finally block exception stops at the point where the exception is thrown
            }
        }

        public void Hello3()
        {
            try
            {
                throw new Exception("Try block Exception");
            }
            // 3 -- a : without handle the try exception the finally block is throwen the the try exception will lost
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            finally
            {
                throw new Exception("Finally block Exception");
            }
        }
        public void Execute()
        {
            //1- whitout handle the exception at the hight level the app will crash
            try
            {
                //Hello();
                // 3- see summary
                Hello3();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
