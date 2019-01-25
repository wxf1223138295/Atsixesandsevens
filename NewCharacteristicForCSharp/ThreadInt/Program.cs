using System;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadInt
{
    class Program
    {
        static async Task MainAsync()
        {
            try
            {
                var id1 = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"延时内部前a {id1}");
                await Task.Delay(1000);
                var id2 = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"延时内部后a {id2}");
            }
            catch (Exception e)
            {

            }
        }
        static async Task MainTaskRun()
        {
            try
            {
                var id1 = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"延时内部前 {id1}");

                await Task.Run(() =>
                {
                    var id3 = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine($"Run里面 {id3}");
                    Task.Delay(2000);
                });

                var id2 = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"延时内部后 {id2}");
            }
            catch (Exception e)
            {

            }
        }


        public static async Task Main(string[] args)
        {


            var id1= Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Start {id1}");


            var t= MainAsync();


            //await MainTaskRun();


            var id2 = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"end {id2}");

            Console.WriteLine(t.IsCompleted);

            await t;

            Console.WriteLine(t.IsCompleted);

            var id4 = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"endend {id4}");








            //ServicePointManager.DefaultConnectionLimit = 1;

            //for (int i = 0; i < 100000; i++)
            //{
            //    Console.WriteLine($"当前循环数：{i}");
            //    Task.Run(() =>
            //    {
            //        Thread.Sleep(8000);
            //        var t = Thread.GetCurrentProcessorId();
            //        Console.WriteLine($"线程ID:{t}");
            //    });
            //}


            //var t = Environment.NewLine;
            //var er = Environment.CommandLine;
            //if (t == "\r\n")
            //    Console.WriteLine($"t = Environment.NewLine true");
            //else
            //{
            //    Console.WriteLine("t = Environment.NewLine false");
            //}
            //string s1 = "已经习惯了回车和换行一次搞定\n，敲一个回车键，即是回";

            //Console.WriteLine(s1);
            //s1 = "已经习惯了回车和换行一次搞定\r，敲一个回车键，即是回";
            //Console.WriteLine(s1);
            //s1 = "已经习惯了回车和换行一次搞定\r\n，敲一个回车键，即是回";
            //Console.WriteLine(s1);

            //await result1;
            //var id4 = Thread.GetCurrentProcessorId();
            //Console.WriteLine($"当前线程await NewFun()（主线程）：{id4}");
            //await result2;
            //var id5 = Thread.GetCurrentProcessorId();
            //Console.WriteLine($"当前线程await NewFun()（主线程）：{id5}");
            //var man = Thread.GetDomainID();
            //Console.WriteLine($"主线程{man}");
            //var t1 = Thread.GetCurrentProcessorId();
            //Console.WriteLine($"{t1}");
            //Task.Run(() =>
            //{
            //    var t=Thread.GetCurrentProcessorId();
            //    Console.WriteLine(t);
            //    Thread.Sleep(4000);
            //});
            //var t2= Thread.GetCurrentProcessorId();
            //Console.WriteLine($"{t2}");

            //Thread.Sleep(6000);
            //var t3 = Thread.GetCurrentProcessorId();
            //Console.WriteLine($"{t3}");
            Console.ReadKey();

        }

        public static int Para()
        {
            Thread.Sleep(6000);
            var t = Thread.GetCurrentProcessorId();
            Console.WriteLine($"线程ID:{t}");
            return t;
        }
        public static async Task<string> UseRun()
        {
            var id1 = Thread.GetCurrentProcessorId();
            Console.WriteLine($"当前线程（NotRun-id1）:{id1}");


            var result = await Task.Run(() =>
            {
                var id2 = Thread.GetCurrentProcessorId();
                Console.WriteLine($"当前线程 Run内部（NotRun-id2）:{id2}");
                Thread.Sleep(5000);
                return "UseRun执行完成";
            });
            var id3 = Thread.GetCurrentProcessorId();
            Console.WriteLine($"当前线程 Run执行完成后 外部（NotRun-id3）:{id3}");

            return result;

        }

        public static async Task<string> NewFun()
        {
            var id1 = Thread.GetCurrentProcessorId();
            Console.WriteLine($"当前线程（NewFun-id1）:{id1}");

            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://www.baidu.com");
            var id2 = Thread.GetCurrentProcessorId();
            Console.WriteLine($"当前线程 await之后（NewFun-id2）:{id2}");
            return result.ToString();
        }
    }
}
