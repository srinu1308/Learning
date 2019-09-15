using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace ASPMVCOnlyOwinAuth.Controllers
{
    [Authorize]
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_post(string txtUserName,string txtUserPassword)
        {
            string userName=System.Configuration.ConfigurationManager.AppSettings["UserName"];
            string password = System.Configuration.ConfigurationManager.AppSettings["UserPassword"];

            if(txtUserName.Equals(userName) && txtUserPassword.Equals(password))
            {
                var claims = new[] { new Claim(ClaimTypes.Name.ToString(), userName) };
                var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(
                    new Microsoft.Owin.Security.AuthenticationProperties()
                    {
                        IsPersistent =false,
                        ExpiresUtc =new DateTimeOffset(DateTime.UtcNow.AddMinutes(1))
                    }, 
                    identity);

                return RedirectToAction("Index", "Home",null);
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            var owincontext=Request.GetOwinContext();
            var authentication=owincontext.Authentication;
            authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "UserLogin", null);
        }
    }
}