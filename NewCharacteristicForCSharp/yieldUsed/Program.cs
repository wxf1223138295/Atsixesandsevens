using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yieldUsed
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (var item in ArryEnumerable())
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("使用yield");
            foreach (var item in YieldDemo())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("不使用yield");
            foreach (var item in Method())
            {
                Console.WriteLine(item);
            }
            foreach (var i in Fibonacci().Take(20))
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        public static IEnumerable<Int32> ArryEnumerable()
        {
            int[] arry = { 1, 2, 3, 4 };
            for (var i = arry.Length - 1; i >= 0; i--)
            {
                yield return arry[i];
            }

            var items = arry.AsEnumerable().Where(p => p.Equals(1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> YieldDemo()
        {
            int counter = 0;
            int result = 1;
            while (counter++ < 10)
            {
                result = result * 2;
                yield return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> Method()
        {
            List<int> results = new List<int>();
            int counter = 0;
            int result = 1;

            while (counter++ < 10)
            {
                result = result * 2;
                results.Add(result);
            }
            return results;
        }
        public static IEnumerable<string> FindBobs(IEnumerable<string> names)
        {          
            foreach (var currName in names)
            {
                if (currName == "Bob")
                    yield return currName;
            }
        }
        private static IEnumerable<int> Fibonacci()
        {
            int current = 1, next = 1;

            while (true)
            {
                yield return current;
                next = current + (current = next);
            }
        }
    }
}
