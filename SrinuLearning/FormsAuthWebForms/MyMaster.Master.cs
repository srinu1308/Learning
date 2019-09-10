using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthWebForms
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];            
            cookie.Expires = DateTime.Now.AddSeconds(-120);
            Response.Cookies.Add(cookie);

            HttpCookie sessionCookie = Request.Cookies["ASP.NET_SessionId"];
            sessionCookie.Expires = DateTime.Now.AddSeconds(-120);
            Response.Cookies.Add(sessionCookie);


            FormsAuthentication.RedirectToLoginPage();
        }
    }
}