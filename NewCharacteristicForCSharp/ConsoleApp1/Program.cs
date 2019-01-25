using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //List<Bouquet> bouquets = new List<Bouquet>() {
        //    //    new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
        //    //    new Bouquet{ Flowers = new List<string> { "tulip", "rose", "orchid" }},
        //    //    new Bouquet{ Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
        //    //    new Bouquet{ Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
        //    //};

        //    Console.ReadKey();
        //}
        //static void Main(string[] args)
        //{
        //    //var createToken = test.MD5($"RICHCLINIC_Gyming_{DateTime.Now:yyyy-MM-dd}");
        //    //Console.WriteLine($"{createToken}");  //dfbafefd35c54e6093cb0c2efe9f9d4b
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {

            //var b = Convert.ToInt32(1) * 1 +
            //        Convert.ToInt32(1) * 2 +
            //        Convert.ToInt32(1) * 4 +
            //        Convert.ToInt32(1) * 8 +
            //        Convert.ToInt32(0) * 16 +
            //        Convert.ToInt32(1) * 32 +
            //        Convert.ToInt32(1) * 64;
            //int week = (int)DateTime.Now.AddDays(1).DayOfWeek;
            //var a = (int)Math.Pow(2, week);
            //var c = a & b;
            Type t = typeof(Class1).MakeByRefType();
            Console.WriteLine("\r\nArray of Example: {0}", t);
            Console.ReadKey();
        }
    }

    //public Type CreateProxy(string assemblyName, string moduleName, string typeName, params PropertyDefine[] props)
    //{
    //    AppDomain domain = Thread.GetDomain();
    //    AssemblyName assembly = new AssemblyName(assemblyName);
    //    assembly.Version = new Version(1, 0, 0, 1);
    //    AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);

    //    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName);

    //    TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public | TypeAttributes.Class, typeof(Object));

    //    foreach (PropertyDefine pd in props)
    //    {
    //        FieldInfo field = typeBuilder.DefineField(pd.FieldName, pd.Type, FieldAttributes.Private);
    //        MethodBuilder getter = typeBuilder.DefineMethod("get_" + pd.PropertyName, MethodAttributes.Public, pd.Type, null);
    //        ILGenerator getterIL = getter.GetILGenerator();
    //        getterIL.Emit(OpCodes.Ldarg_0);
    //        getterIL.Emit(OpCodes.Ldfld, field);
    //        getterIL.Emit(OpCodes.Ret);
            

    //        MethodBuilder setter = typeBuilder.DefineMethod("set_" + pd.PropertyName, MethodAttributes.Public, null, new Type[] { pd.Type });
    //        ILGenerator setterIL = setter.GetILGenerator();
    //        setterIL.Emit(OpCodes.Ldarg_0);
    //        setterIL.Emit(OpCodes.Ldarg_1);
    //        setterIL.Emit(OpCodes.Stfld, field);
    //        setterIL.Emit(OpCodes.Ret);

    //        PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(pd.PropertyName, PropertyAttributes.None, pd.Type, Type.EmptyTypes);
    //        propertyBuilder.SetGetMethod(getter);
    //        propertyBuilder.SetSetMethod(setter);
    //    }

    //    return typeBuilder.CreateType();
    //}

    public class test
    {
        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');

            }
            return str;
        }
    }
}
