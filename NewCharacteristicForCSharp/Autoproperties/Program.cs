using System;
using System.Collections.Generic;
using static System.String;

namespace Autoproperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // 重复键入类名可能会导致代码的含义难以理解
            string map = "";
            if (IsNullOrEmpty(map))
            {
                
            }
            

            //NULL条件运算符
            var student=new Student();
            var secondname = student?.SecondName;
            //等于
            //var student = new Student();

            //string firstName = null;
            //if (student != null)
            //{
            //    firstName = student.FirstName;
            //}
            //字符串插值
            var value1 = "占位1";
            var value2 = "占位2";
            Console.WriteLine($"{value1}-----{value2}");
       
            //异常过滤器
            // 异常筛选器是确定何时应该应用给定的 catch 子句的子句。 如果用于异常筛选器的表达式计算结果为 true，则 catch 子句将对异常执行正常处理。 如果表达式计算结果为 false，则将跳过 catch 子句。
            //
            try
            {

            }
            catch (OverflowException ex) 
            {

            }
            catch (FormatException e) when(e.GetType() != typeof(System.FormatException))//如果这边不需要throw  when 后面永远放false就行   ：如日志记录       
            {
                
            }
            //when 条件满足了  就会throw  
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                //if (e.Message.Contains("301"))
                //    return "Site Moved";
                //else
                //    throw;
            }

            var dic = new Dictionary<int, string>()
              {
                [20] = "Mike",
                [30] = "Jim"
            };

            Console.ReadKey();
        }
        public static bool LogException(Exception e)
        {
            Console.Error.WriteLine($"Exceptions happen: {e}");
            return false;
        }
        public void TestFunc()
        {
            
        }
        //C#6中提供的一个新语法：对于只有一条语句的方法体可以简写成表达式
        //函数成员的表达式体
        private Student NewCreate() => new Student();
        private Student Create()
        {
            return new Student();
        }
    }
}
