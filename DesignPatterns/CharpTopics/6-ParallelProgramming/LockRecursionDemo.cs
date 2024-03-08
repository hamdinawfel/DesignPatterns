using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics._6_ParallelProgramming
{
    public class LockRecursionDemo : IExecuteDemo
    {
        private void LockRecursion(int x, SpinLock spinLock)
        {
            bool isLockTeken = false;
            try
            {
                spinLock.Enter(ref isLockTeken);
            }
            catch(LockRecursionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (isLockTeken)
                {
                    Console.WriteLine($"Lock taken by x : {x}");
                    LockRecursion(x - 1, spinLock);
                    spinLock.Exit();
                }
                else
                {
                    Console.WriteLine($"Failed to take lock by x : {x}");
                }
            }
        }
        public void Execute()
        {
            SpinLock spinLock = new SpinLock();
            LockRecursion(5, spinLock);
        }
    }
}
