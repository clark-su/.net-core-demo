using Microsoft.EntityFrameworkCore;
using NetCore.Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreConsole
{
    public delegate string MyDelegate(string name);

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Task<string> ts = Msg();
            //Console.WriteLine("异步程序加载中..");
            //Console.WriteLine(ts.Result);


            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Hello World!");
            Task<string> ts1 = Msg1();
            Task<string> ts2 = Msg();
            Console.WriteLine("异步程序加载中..");
            Console.WriteLine(ts1.Result);

            DeledateHander hander = new DeledateHander();
            hander.myDeledate += User.MyName;
            hander.MyMenth("clark");

            //Action委托，没有返回值
            hander.MyAction1<string>(User.MyName1, "张三");

            //Func委托
            Console.WriteLine(hander.MyFunc<string>(User.GetAll, "李四"));

            //Teacher.InsertUser();
            //获取缓存数据
            string val = RedisCache.Cache.GetValue("U354e87854");
            Console.WriteLine(val);

            Console.ReadLine();
        }

        public static async Task<string> Msg()
        {
            string data =await News();
            Console.WriteLine("2异步调用程序结束..");

            return data;
        }

        public static async Task<string> Msg1()
        {
            string data = await News();
            Console.WriteLine("1异步调用程序结束..");

            return data;
        }

        public static Task<string> News()
        {
            Console.WriteLine("111111..");
            return Task<string>.Run(() =>
            {
                Thread.Sleep(5000);
                return "hello async";
            });
        }

        public static async Task<string> Msg3()
        {
            string data = await Msg1();

            return data;
        }

    }

    public class DeledateHander
    {
        public event MyDelegate myDeledate;

        public void MyMenth(string name)
        {
            Console.WriteLine(myDeledate(name));
        }

        public void MyAction(string name, Action action)
        {
            action();
        }

        public void MyAction1<T>(Action<T> action, T name)
        {
            action(name);
        }

        public string MyFunc<T1>(Func<T1, string> func, T1 obj)
        {
            return func(obj);
        }

        public static ResultMsg<T> Execute<T>(Func<ResultMsg<T>> func)
        {
            try
            {
                return func();
            }
            catch
            {
                return new ResultMsg<T>(0, "fail", default(T));
            }
        }

        public static ResultMsg Execute(Func<ResultMsg> func)
        {
            try
            {
                return func();
            }
            catch
            {
                return new ResultMsg(0, "fail");
            }
        }
    }

    public class Teacher
    {

        public ResultMsg<DataTable> GetTeacher()
        {
            return DeledateHander.Execute<DataTable>(() => new ResultMsg<DataTable>(1, "success", Menth.GetUser()));
        }

        public static ResultMsg InsertUser()
        {
            return DeledateHander.Execute(() => new ResultMsg(AddUser() ? 1 : 0, "success"));
        }

        public static bool AddUser()
        {
            var data = new { name = "clark", sex = 0, year = 1988, des = "浩然的父亲" };
            return RedisCache.Cache.Insert<dynamic>("U354e87854", data);
        }
    }

    public class User
    {
        public static void MyName1(string name)
        {
            Console.WriteLine(name);
        }

        public static string MyName(string name)
        {
            return name;
        }

        public static string GetAll(string content)
        {
            return content;
        }
    }

    public class Menth
    {
        public static DataTable GetUser()
        {
            return null;
        }
    }
}
