using NetCore.Common.Data;
using NetCore.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NetCore.DTO
{
    public class UserDTO : DbContext<User>
    {
        public static IList<User> GetAllUsers()
        {
            string sql = "select * from Admin";
            return Fetch(sql);
        }

        public static string GetString()
        {
            return "OK";
        }
    }
}
