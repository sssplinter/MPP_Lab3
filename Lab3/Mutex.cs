
using System;
using System.Threading;

namespace Lab3
{
    public class Mutex
    {
        private int _lockThreadId;
        
        public void Lock()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref _lockThreadId, currentThreadId, 0) != 0)
            {
                Thread.Sleep(100);
            }
        }

        public void Unlock()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref _lockThreadId, 0, currentThreadId);
        }
    }
}