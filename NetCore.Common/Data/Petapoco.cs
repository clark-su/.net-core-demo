using NetCore.Common.Common;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NetCore.Common.Data
{
    public class Petapoco : Database
    {
        private static readonly SqlConnection sqlcon = new SqlConnection(ConfigHelper.Config.Con);

        public Petapoco() : base(sqlcon)
        {
        }

        public IList<T> Fetch<T>(string sql, params object[] args)
        {
            return base.Fetch<T>(sql, args);
        }

        public int Delete<T>(string sql, params object[] args)
        {
            return base.Delete<T>(sql, args);
        }

        public int Delete<T>(string primaryKey)
        {
            return base.Delete<T>(primaryKey);
        }

        public object Insert(object poco)
        {
            return base.Insert(poco);
        }
    }
}
