using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASPMVCBasicAuthCheck
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

        protected void Application_AuthenticateRequest()
        {
           if( Request.Url.AbsolutePath.ToLower()
                .Contains("contact"))
            {
                GenericIdentity identity = new GenericIdentity("testuser");
                GenericPrincipal pricipal = new GenericPrincipal(identity, null);
                this.Context.User = pricipal;
                
            }            
        }
    }
}
