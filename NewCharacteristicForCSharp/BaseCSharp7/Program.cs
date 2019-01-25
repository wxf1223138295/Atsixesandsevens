using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace BaseCSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Add(1, 2, out var para);
            //int para;
            //Add(1, 2,out para);
            //创建元祖
            var tuple = (1, 2);                           // 使用语法糖创建元组
            var tuple2 = ValueTuple.Create(1, 2);         // 使用静态方法【Create】创建元组
            var tuple3 = new ValueTuple<int, int>(1, 2);  // 使用 new 运算符创建元组

            // 左边指定字段名称
            (int one, int two) tuple4 = (1, 2);


            // 右边指定字段名称
            var tuple5 = (one: 1, two: 2);


            // 左右两边同时指定字段名称
            (int one, int two) tuple6 = (first: 1, second: 2);    /* 此处会有警告：由于目标类型（xx）已指定了其它名称，因为忽略元组名称xxx */
            Tuple<string, int> oldInfo = Tuple.Create("xiaofeng", 12);
            string name = oldInfo.Item1;
            int age = oldInfo.Item2;

            Tuple<string, string> oldInfo2 = Tuple.Create("名字", "性别");
            string name2 = oldInfo2.Item1;
            string sex = oldInfo2.Item2;
            //没有解构，拿错数据
            string name3 = oldInfo2.Item2;
            string sex1 = oldInfo2.Item1;

            (string name, int age) info = new ValueTuple<string, int>("xiaofeng", 1);
            string a = info.name;
            int b = info.age;


            //弃元
            //通常，在进行元组解构或使用 out 参数调用方法时，必须定义一个其值无关紧要且你不打算使用的变量。 为处理此情况，C# 增添了对弃元的支持。 弃元是一个名为 _（下划线字符）的只写变量，可向单个变量赋予要放弃的所有值。 弃元类似于未赋值的变量；不可在代码中使用弃元（赋值语句除外）。


            //此 is 非彼 is ，这个扩展的 is 其实是 as 和 if 的组合。即它先进行 as 转换再进行 if 判断，判断其结果是否为 null，不等于 null 则执行语句块逻辑，反之不行。
            var sum = 0;
            IEnumerable<object> values = new List<object>();
            foreach (var item in values)
            {
                if (item is short)     // C# 7 之前的 is expressions
                {
                    sum += (short)item;
                }
                else if (item is int val)  // C# 7 的 is expressions
                {
                    sum += val;
                }
                else if (item is string str && int.TryParse(str, out var result))  // is expressions 和 out variables 结合使用
                {
                    sum += result;
                }
            }


            //?:  ??  Lambda
            int aa = 0;
            string _name = GetResult().ToString() ?? throw new ArgumentNullException(nameof(GetResult));



             var one = 0b0001;
             var sixteen = 0b0001_0000;
           
             long salary = 1000_000_000;
             decimal pi = 3.141_592_653_589m;
        }
        //Install - Package System.Threading.Tasks.Extensions
        public async static ValueTask<int> Func()
        {
            await Task.Delay(3000);
            return 100;
        }
        public static int GetResult()
        {
            return 3;
        }
        //switch语句更新
        static int GetSum(IEnumerable<object> values)
        {
            var sum = 0;
            if (values == null) return 0;

            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:                // 常量模式匹配
                        break;
                    case short sval:       // 类型模式匹配
                        sum += sval;
                        break;
                    case int ival:
                        sum += ival;
                        break;
                    case string str when int.TryParse(str, out var result):   // 类型模式匹配 + 条件表达式
                        sum += result;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += GetSum(subList);
                        break;
                    default:
                        throw new InvalidOperationException("未知的类型");
                }
            }

            return sum;
        }

        public static void Add(int x, int y, out int result)
        {
            result = x + y;
        }

        /// <summary>
        /// 局部函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static IEnumerable<char> GetCharList(string str)
        {
            if (IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(nameof(str));

            return GetList();


            IEnumerable<char> GetList()
            {
                for (int i = 0; i < str.Length; i++)
                {

                    yield return str[i];
                }
            }
        }
    }
}
