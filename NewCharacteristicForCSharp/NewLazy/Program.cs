using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLazy
{
    class Program
    {
        static Lazy<objectTest> tempObj = null;

        static objectTest InitLargeObject()
        {
            objectTest large = new objectTest(Thread.CurrentThread.ManagedThreadId);
            // Perform additional initialization here.
            return large;
        }
        static void Main(string[] args)
        {
            //Lazy<objectTest> tempObj = new Lazy<objectTest>();
            //Console.WriteLine(tempObj.IsValueCreated);
            //Console.WriteLine(tempObj.Value.returnSum());


            //Console.WriteLine(tempObj.IsValueCreated);
            //多线程
            tempObj = new Lazy<objectTest>(InitLargeObject,true);

            Parallel.For(0, 4, (i) =>
            {
               var lage= tempObj.Value;
                lock (lage)
                {
                    Console.WriteLine("Initialized by thread {0}; last used by thread {1}.", lage.i, Thread.CurrentThread.ManagedThreadId);
                }
            });
            //Resfd d = new Resfd();
            //var r = Console.ReadLine();

            //var result=d.func(Convert.ToInt32(r));
            //Console.WriteLine(result);
            Console.ReadKey();
        }


    }

    public class Resfd
    {
        public int func(int dex)
        {
            if (dex < 3)
            {
                return 1;
            }
            else
            {
                return func(dex-1) + func(dex - 2);
            }

       
        }
    }
    public class objectTest
    {
        public int i = 0;
        public objectTest(int threadid)
        {
            i = threadid;
        }
            
        public int num { get; set; }

        public int returnSum()
        {
            num = num + 9;
            return num;
        }
    }
}
