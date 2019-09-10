using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FormsAuthWebForms
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var x = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var x = 0;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var x = 0;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(authCookie != null)
            {
                FormsAuthenticationTicket ticket=FormsAuthentication.Decrypt(authCookie.Value);
                string name = ticket.Name;
                var identity = new GenericIdentity(name);
                var principal = new GenericPrincipal(identity, null);
                Context.User = principal;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var x = 0;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            var x = 0;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            var x = 0;
        }
    }
}