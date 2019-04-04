using System;

namespace NetCore.Model
{
    public class User
    {
        public int Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_NickName { get; set; }
        public string Admin_Pwd { get; set; }
        public int Admin_RoleId { get; set; }
        public int Admin_JcsId { get; set; }
        public int Admin_State { get; set; }
        public DateTime Admin_AddTime { get; set; }
        public DateTime Admin_UpdateTime { get; set; }
        public string Admin_LoginIp { get; set; }
        public DateTime Admin_LoginTime { get; set; }
        public int Admin_Create_AdminId { get; set; }
        public string Admin_Experience { get; set; }
        public string Admin_Pic { get; set; }
        public int Website_Id { get; set; }

    }
}
