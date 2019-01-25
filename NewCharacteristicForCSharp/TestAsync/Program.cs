using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TestAsync();
            //Console.WriteLine("中间的3");
            //Console.ReadKey();

            Console.WriteLine("我是主线程，线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            await TestAsync2();
            Console.ReadLine();
        }

        public static async Task TestAsync2()
        {
            Console.WriteLine("调用GetReturnResult()之前，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            var name =await GetReturnResult();
            Console.WriteLine("调用GetReturnResult()之后，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            Console.WriteLine("得到GetReturnResult()方法的结果：{0}。当前时间：{1} 线程ID：{2}。", name, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"), Thread.CurrentThread.ManagedThreadId);
        }
        static async Task<string> GetReturnResult()
        {
            Console.WriteLine("执行Task.Run之前, 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("GetReturnResult()方法里面线程ID: {0}", Thread.CurrentThread.ManagedThreadId);
                return "我是返回值";
            });
        }

        public static async Task TestAsync()
        {
            await tesTask1();
            Console.WriteLine("中间的");
            await tesTask2();
            Console.WriteLine("中间的1");
        }

        private static async Task tesTask1()
        {
            Console.WriteLine("tesTask1 start");
            for (int i = 0; i < 10; i++)
            {
               

                await Task.Run(()=>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{i}!~~~");
                }); 
            }
            Console.WriteLine("tesTask1 end");
        }

        private static async Task tesTask2()
        {
            for (int i = 0; i < 10; i++)
            {
              

              await Task.Run(()=>
              {
                  Thread.Sleep(2000);
                  Console.WriteLine($"{i}!#####");
              }); 
            }
        }
    }
}
