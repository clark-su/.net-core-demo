using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsole
{
    public class ResultMsg
    {
        public ResultMsg(int code,string msg)
        {
            this.code = code;
            this.msg = msg;
        }
        public int code { get; set; }

        public string msg { get; set; }
    }

    public class ResultMsg<T>: ResultMsg
    {
        public ResultMsg(int code,string msg,T data):base(code,msg)
        {
            this.data = data;
        }
        public T data { get; set; }
    }

}
