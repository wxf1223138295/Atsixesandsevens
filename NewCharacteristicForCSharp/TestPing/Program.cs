using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestPing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "测试网络是否通畅v1.0";
            //Ping 实例对象;
            Ping pingSender = new Ping();
            //ping选项;
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "ping test data";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            //调用同步send方法发送数据，结果存入reply对象;
            while (true)
            {
                Thread.Sleep(1000);
                await Task.Run(() =>
            {

                
                var _Iplist = System.Configuration.ConfigurationManager.AppSettings["IPs"];
                //一个IP 无需循环
                if (!_Iplist.Contains('|'))
                {
                    PingReply reply = pingSender.Send(_Iplist, 5000, buf, options);

                    if (reply.Status != IPStatus.Success)
                    {
                        Console.WriteLine("主机地址::" + reply.Address + "失败");
                        Console.WriteLine("时间：" +DateTime.Now);
                        
                    }
                    if (reply.Status == IPStatus.TimedOut)
                    {
                        Console.WriteLine($"访问：{_Iplist} 超时");
                    }
                    if (reply.Status == IPStatus.TimeExceeded)
                    {
                        Console.WriteLine($"访问：{_Iplist} TTL峰值为0,数据包丢失");
                    }
                    if (reply.Status == IPStatus.Unknown)
                    {
                        Console.WriteLine($"访问：{_Iplist} 回显失败，原因未知");
                    }
                }
                else
                {
                    var value = _Iplist.Split('|');
                    foreach (var item in value)
                    {                        
                        PingReply reply = pingSender.Send(item, 100, buf, options);

                        if (reply.Status != IPStatus.Success)
                        {
                            Console.WriteLine("主机地址::" + reply.Address + "失败");
                            Console.WriteLine("往返时间::" + reply.RoundtripTime);
                        }
                        if (reply.Status == IPStatus.TimedOut)
                        {
                            Console.WriteLine($"访问：{_Iplist} 超时");
                        }
                        if (reply.Status == IPStatus.TimeExceeded)
                        {
                            Console.WriteLine($"访问：{_Iplist} TTL峰值为0,数据包丢失");
                        }
                        if (reply.Status == IPStatus.Unknown)
                        {
                            Console.WriteLine($"访问：{_Iplist} 回显失败，原因未知");
                        }
                    }
                }





            }
                );

            }
        }
    }
}
