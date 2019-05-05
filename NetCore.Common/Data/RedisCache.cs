using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Common.Data
{
    public class RedisCache :RedisData
    {
        private static RedisCache cache = null;
        public RedisCache() : base("127.0.0.1:6379")
        {

        }

        public static RedisCache Cache
        {
            get
            {
                if (cache == null)
                    cache = new RedisCache();
                return cache;
            }
        }

        public bool Insert(string key, string val)
        {
            return SetString(key, val);
        }

        public bool Insert<T>(string key, T Tresult)
        {
            return SetString<T>(key, Tresult);
        }

        public string GetValue(string key)
        {
            return GetString(key);
        }
    }
}
