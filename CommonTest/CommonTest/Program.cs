using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern;
using DesignPattern.Decoration;
using DesignPattern.Decoration.hair;
using System.IO;
using Common.Serialize;
using MyThreads;

namespace CommonTest
{
    class Program
    {
        static void Main(string[] args)
        {
             DemoManualResetEventShow.Show();
            //DemoCancellationTokenSource aa = new DemoCancellationTokenSource();
            //aa.FooRun();
            Console.ReadLine();
        }
    }
}
