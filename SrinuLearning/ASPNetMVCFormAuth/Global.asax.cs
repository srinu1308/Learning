﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ASPNetMVCFormAuth
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //if(authCookie !=null)
            //{
            //    FormsAuthenticationTicket ticket= FormsAuthentication.Decrypt(authCookie.Value);
            //    string userName = ticket.Name;

            //    if(!string.IsNullOrEmpty(userName))
            //    {
            //        GenericIdentity identity = new GenericIdentity(userName);
            //        GenericPrincipal principal = new GenericPrincipal(identity,null);
            //        //this.Context.User = principal;
            //    }
            //}
        }

    }
}
