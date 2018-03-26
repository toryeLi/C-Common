using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyThreads
{
    public class DemoManualResetEvent
    {
        private ManualResetEvent _man;
       CancellationTokenSource cancellationTokenSource;
        public DemoManualResetEvent() {
            _man = new ManualResetEvent(true);
            cancellationTokenSource = new CancellationTokenSource();
        }
        public void ManRet() {
            _man.Reset();
        }
        public void ManSet() {
            _man.Set();
        }
        public void Cancellation() {
            cancellationTokenSource.Cancel();
        }
        public void Run() {
            while (true) {
                if (!cancellationTokenSource.IsCancellationRequested) { 
                _man.WaitOne();
            Console.WriteLine($"Thread<{Thread.CurrentThread.ManagedThreadId}> is Runing...");
                }
                Thread.Sleep(1000);
            }
        }
        public void Show() {
            Thread thread = new Thread( new ThreadStart(Run));
            thread.Start();
            Thread t2 = new Thread(new ThreadStart(Run));
            t2.Start();
        }
    }
    public class DemoManualResetEventShow {
        public static void Show() {
            try
            {
                DemoManualResetEvent demoManualResetEvent = new DemoManualResetEvent();
                demoManualResetEvent.Show();
                while (true)
                {
                    string read = Console.ReadLine();
                    if (read.Trim().ToLower().Equals("stop"))
                    {
                        demoManualResetEvent.ManRet();
                    }
                    if (read.Trim().ToLower().Equals("run"))
                    {
                        demoManualResetEvent.ManSet();
                    }
                    if (read.Trim().ToLower().Equals("can")) {
                        demoManualResetEvent.Cancellation();
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }


}
