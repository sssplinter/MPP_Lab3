using System;
using System.Threading;

namespace Lab3
{
    internal class Program
    {
        private static Mutex mutex = new Mutex();
        
        public static void Main(string[] args)
        {
            var thread1 = new Thread(Calculate);
            thread1.Start();
            var thread2 = new Thread(Calculate);
            thread2.Start();
            var thread3 = new Thread(Calculate);
            thread3.Start();
        }

        private static void Calculate()
        {
            mutex.Lock();
            for (var i = 0; i < 10; i++)
            {
                Console.Out.WriteLine("Thread {0} - {1}", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(500);
            }
            mutex.Unlock();
        }
    }
}