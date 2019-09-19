using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPMVCAPIOAuthToken.Controllers
{
    [Authorize]
    public class UserAPIController : ApiController
    {
         public class MyUser
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static List<MyUser> listUser = new List<MyUser>()
        {
            new MyUser() {ID="srinu1308",Name="srinu",Age=29 },
            new MyUser() {ID="Nagato1308",Name="Nagato",Age=30 },
            new MyUser() {ID="Yahiko1308",Name="Yahiko",Age=32 }
        };

        [System.Web.Http.HttpGet]
        public List<MyUser> Get()
        {
            return listUser;
        }

        [System.Web.Http.HttpGet]
        public MyUser Get(string ID)
        {
            return listUser.Where(x => x.Name== ID).FirstOrDefault();
        }

        [System.Web.Http.HttpPut]
        public void Put(MyUser user)
        {
            MyUser rUser = listUser.Where(x => x.Name == user.Name).First();
            rUser.Name = user.Name;
            rUser.Age = user.Age;
        }

        [System.Web.Http.HttpPost]
        public void Post(MyUser user)
        {
            string ID = user.Name + "1308";
            user.ID = ID;
            listUser.Add(user);
        }

        [System.Web.Http.HttpDelete]
        public void Delete(string Name)
        {
            MyUser user = listUser.Where(x => x.Name == Name).First();
            listUser.Remove(user);
        }
    }
}
