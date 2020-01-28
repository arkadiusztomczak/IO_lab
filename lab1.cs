using System;
using System.Threading;

namespace laby1
{
    class Program
    {
        public zad1()
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { 600 });
            ThreadPool.QueueUserWorkItem(ThreadProc, new object[] { 300 });
            Thread.Sleep(2000);
        }

        static void ThreadProc(Object stateInfo)
        {
            var time = ((object[])stateInfo)[0];
            Thread.Sleep((int)time);
            Console.WriteLine("Oczekiwano " + (int)time + "ms.");
        }
    }
}
