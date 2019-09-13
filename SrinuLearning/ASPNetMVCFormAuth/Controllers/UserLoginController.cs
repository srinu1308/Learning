using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPNetMVCFormAuth.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [ActionName("Login")]
        [HttpPost]
        public ActionResult LoginPost(string txtUserName, string txtPassword)
        {
            Boolean isUserAuthenticated = FormsAuthentication.Authenticate(txtUserName, txtPassword);
            //Boolean isUserAuthenticated = true;
            if (isUserAuthenticated)
            {
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(txtUserName, false);
                authCookie.Expires = DateTime.Now.AddSeconds(60);
                authCookie.Path="/";
                Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }            
            
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}