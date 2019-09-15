using System.Web;
using System.Web.Mvc;

namespace ASPMVCOnlyOwinAuth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
