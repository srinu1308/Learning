using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCAPIOAuthToken.Models;
using Owin;
using Microsoft.AspNet.Identity;

namespace ASPMVCAPIOAuthToken.Controllers
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

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult UserByName()
        {
            List<string> listUsers = MyUser.GetUserNames();
            return View(listUsers);
        }

        public ActionResult LogOut()
        {
            var owincontext = Request.GetOwinContext();
            var authentication = owincontext.Authentication;
            authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            authentication.SignOut(DefaultAuthenticationTypes.ExternalBearer);

            HttpCookie cookie = Request.Cookies[".AspNet.Cookies"];
            cookie.Expires = DateTime.Now.AddMinutes(-2);
            cookie.Value = string.Empty;
            cookie.Path="/";

            Response.Cookies.Add(cookie);
            return RedirectToAction("Login", "userLogin", null);


        }
    }
}