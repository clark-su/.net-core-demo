using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NetCore.Common.Data
{
    public class DbContext<T>
    {
        private static readonly object _lock = new object();
        private static Petapoco pcoc = null;

        static DbContext()
        {
            if (pcoc == null)
            {
                lock (_lock)
                {
                    pcoc = new Petapoco();
                }
            }
        }

        public static IList<T> Fetch(string sql, params object[] args)
        {
            return pcoc.Fetch<T>(sql,args);
        }

        public static int Delete(string sql, params object[] args)
        {
            return pcoc.Delete<T>(sql, args);
        }

        public static int Delete(string primaryKey)
        {
            return pcoc.Delete<T>(primaryKey);
        }

        public static object Insert(object poco)
        {
            return pcoc.Insert(poco);
        }
    }
}
