using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Marketo.Mis
{
    public class TransferManager
    {
        public void DoDoubleTransfer(Account ac1, Account ac2)
        {
            Debug.WriteLine("starting...");
            var task1 = Transfer(ac1, ac2, 500);
            var task2 = Transfer(ac2, ac1, 600);
            Task.WaitAll(task1, task2);
            Console.WriteLine("finished...");
        }

        private Task Transfer(Account ac1, Account ac2, int sum)
        {
            var task = Task.Run(() =>
            {
                lock (ac1)
                {
                    Thread.Sleep(1000);
                    lock (ac2)
                    {
                        Console.WriteLine($"finished transferring sum {sum}");
                    }
                }
            });
            return task;
        }
        private Task TransferSameOrder(Account acc1, Account acc2, int sum)
        {
            var lock1 = acc1.Id < acc2.Id ? acc1 : acc2;//smalled Id account
            var lock2 = acc1.Id < acc2.Id ? acc2 : acc1;//biggest Id account
            var task = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        //Console.WriteLine($"Finished transferring sum {sum}");
                        Debug.WriteLine($"Finished transferring sum {sum}");
                    }
                }
            });
            return task;
        }

        private Task TransferTimeOut(Account acc1, Account acc2, int sum)
        {
            var task = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        bool entered = Monitor.TryEnter(acc1, TimeSpan.FromMilliseconds(100));
                        if (!entered) continue;
                        entered = Monitor.TryEnter(acc2, TimeSpan.FromMilliseconds(100));
                        if (!entered) continue;

                        // do operation
                        Console.WriteLine($"finished transferring sum {sum}");
                    }
                    finally
                    {
                        if (Monitor.IsEntered(acc1)) Monitor.Exit(acc1);
                        if (Monitor.IsEntered(acc2)) Monitor.Exit(acc2);
                        Thread.Sleep(200);
                    }
                }
            });
            return task;
        }


    }

    public class Account
    {
        public uint Id { get; set; }
    }
}
