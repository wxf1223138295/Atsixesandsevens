using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoproperties
{
    public class Student
    {

        #region 只读自动属性
        //只读自动属性
        //C#6之前
        public Student(string firstName)
        {
            FirstName = firstName;
        }
        public Student()
        {

        }

        public string FirstName { get; private set; }
        //C#6
        public string NewFirstName { get; }
        //自动属性初始化器
        //按之前的写法要在构造函数中赋值
        public string SecondName { get; set; } = "Value";

        public ICollection<double> Grades { get; set; } = new List<double>();
        #endregion

        #region 函数成员表达式
        public string FullName => string.Format("{0},{1}", FirstName, SecondName);
        //相当于
        //public string FullName
        //{
        //    get
        //    {
        //        return string.Format("{0},{1}", FirstName, LastName);
        //    }
        //}

        #endregion

    }
}
