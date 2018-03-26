using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyThreads
{
   public  class DemoCancellationTokenSource
    {
        public void FooRun() {
            Console.WriteLine("Create a new thread in ThreadPool...");
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("CancellationTokenSource is Cancel"));
            ThreadPool.QueueUserWorkItem(o=>LoopFoo(cts.Token,100));
            Thread.Sleep(180);
            cts.Cancel();
            Console.WriteLine("FooRun Done...");
        }
        public void LoopFoo(CancellationToken cancellationToken,int countTo) {
            int i = 0;
            while (i++ < countTo) {
                if (cancellationToken.IsCancellationRequested) {
                    Console.WriteLine("Is canceled...");
                }
                Console.WriteLine(i);
                Thread.Sleep(10);
            }
            Console.WriteLine("LoopFoo Done...");
        }


        public void FooRun2()
        {
            CancellationTokenSource one = new CancellationTokenSource();
            one.Token.Register(()=>Console.WriteLine("One register function invoked..."));
            CancellationTokenSource two = new CancellationTokenSource();
            two.Token.Register(()=>Console.WriteLine("Two register funtion invoked..."));
            CancellationTokenSource three = CancellationTokenSource.CreateLinkedTokenSource(one.Token,two.Token);
            three.Token.Register(()=>Console.WriteLine("Three register function invoked..."));
            Console.WriteLine($"One's IsCancellationRequested:{one.IsCancellationRequested}\nTwo's IsCancellationRequested:{two.IsCancellationRequested}\nThree's IsCancellationRequested:{three.IsCancellationRequested}");
            one.Cancel();
            Console.WriteLine($"One's IsCancellationRequested:{one.IsCancellationRequested}\nTwo's IsCancellationRequested:{two.IsCancellationRequested}\nThree's IsCancellationRequested:{three.IsCancellationRequested}");
        }
       
    }
}
