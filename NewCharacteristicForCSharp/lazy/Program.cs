using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lazy
{
    class Program
    {
        static void Main(string[] args)
        {
            demoClass c=new demoClass();


            WeakReference wref = new WeakReference(c);
            var c2 = wref.Target;
            if (c2 != null)
            {
                //TODO
            }
            else
            {
                // TODO 对象已经被回收，如果要用必须新建一个。

            }



            //YaLazy<demoClass> yt=new YaLazy<demoClass>();
            //Console.WriteLine(yt.IsValid);
            //var result = yt.Value.getsum();
            //Console.WriteLine(result);
            //Console.WriteLine(yt.IsValid);

            Console.ReadKey();
        }

    }

    public class demoClass
    {
        public int num { get; set; }

        public int getsum()
        {
            num= num + 2;
            return num;
        }
    }
    public class YaLazy<T>
    {
        public bool IsValid = false;
        public YaLazy()
        {

        }
     
        private T _value;
        public T Value
        {
            get
            {
                if (this._value != null)
                {
                    return (T)_value;
                }
                _value = (T)Activator.CreateInstance(typeof(T));
                IsValid = true;
                return _value;
            }
        }
    }
}
