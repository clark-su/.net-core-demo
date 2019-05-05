using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Common.Data
{
    public class RedisData
    {
        private IDatabase db = null;
        private readonly object obj_lock = new object();
        public RedisData(string connection)
        {
            //链接到redis
            if (string.IsNullOrEmpty(connection))
                throw new Exception("redis链接地址不存在");
            lock (obj_lock)
            {
                var redis = ConnectionMultiplexer.Connect(connection);
                db = redis.GetDatabase();
            }
        }

        public bool SetString(string key, string val)
        {
            return db.StringSet(key, val);
        }

        public async Task<bool> SetStringAsync(string key, string val)
        {
            return await db.StringSetAsync(key, val);
        }

        public bool SetString(string key, string val, double ts)
        {
            return db.StringSet(key, val, TimeSpan.FromSeconds(ts));
        }

        public bool SetString<T>(string key, T t, TimeSpan? ts = default(TimeSpan?))
        {
            string value = JsonConvert.SerializeObject(t);
            return db.StringSet(key, value);
        }

        public string GetString(string key)
        {
            return db.StringGet(key);
        }

        public T GetObject<T>(string key)
        {
            return !string.IsNullOrEmpty(db.StringGet(key).ToString()) ? JsonConvert.DeserializeObject<T>(db.StringGet(key).ToString()) : default(T);
        }

        public long SetList<T>(string key, RedisValue pivot, RedisValue value)
        {
            return db.ListInsertAfter(key, pivot, value);
        }

    }
}
