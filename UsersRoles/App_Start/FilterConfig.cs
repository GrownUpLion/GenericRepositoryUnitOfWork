using Domain.Interfaces;
using UsersAdmin.Helpers;
using System.Web;
using System.Web.Mvc;

namespace UsersAdmin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomWindowsAuthorization());
        }
    }
}
