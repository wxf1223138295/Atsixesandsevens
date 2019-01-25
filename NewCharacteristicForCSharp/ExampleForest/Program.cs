using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleForest
{

    class Program
    {
        static void Main(string[] args)
        {
            //发布者
            Server s = new Server();
            //订阅者
            Client1 c1 = new Client1(s);
            Client2 c2 = new Client2(s);
            s.Send("Hello");
            publishobject.DelegateEvent += Dad.Eat;


            Console.WriteLine(publishobject.cook());

            publishobject.DelegateEvent += Child.Eat;

            Console.WriteLine(publishobject.cook());

            Console.ReadKey();
        }
    }

    //服务器
    public class Server
    {
        //服务器发布的事件
        public event Action<string> MyEvent;
        public void Send(string msg)
        {
            if (MyEvent != null)
            {
                Console.WriteLine("Server推送消息：" + msg);
                MyEvent(msg);
            }
        }
    }
    public class Client2
    {
        public Client2(Server s)
        {
            //客户端订阅
            s.MyEvent += Receive;
        }

        public void Receive(string msg)
        {
            Console.WriteLine("Client2收到了通知：" + msg);
        }
    }
    //客户端
    public class Client1
    {
        public Client1(Server s)
        {
            //客户端订阅
            s.MyEvent += Receive;
        }

        public void Receive(string msg)
        {
            Console.WriteLine("Client1收到了通知：" + msg);
        }
    }

    public delegate  string CallEat(string txt);//第一步：定义委托类型
    public class publishobject
    {
        public static string temp = string.Empty;
        public static event CallEat DelegateEvent;//声明委事件

        public static string cook()
        {
            Console.WriteLine("饭好了");
            return DelegateEvent(temp);
        }
    }

    public class Dad
    {
        public static string Eat(string msg1)
        {
            publishobject.temp = "爸爸";

            return publishobject.temp;
        }

    }
    public class Child
    {
        public static string Eat(string msg2)
        {
            publishobject.temp = "宝宝";
            return publishobject.temp;
        }

    }
}
