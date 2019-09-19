using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVCAPIOAuthToken.Models
{
    public class MyUser
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static List<MyUser> listUser = new List<MyUser>()
        {
            new MyUser() {ID="srinu1308",Name="srinu",Age=29 },
            new MyUser() {ID="Nagato1308",Name="Nagato",Age=30 },
            new MyUser() {ID="Yahiko1308",Name="Yahiko",Age=32 }
        };

        public static List<string> GetUserNames()
        {
            return listUser.Select(x => x.Name).ToList<string>();
        }
    }
}