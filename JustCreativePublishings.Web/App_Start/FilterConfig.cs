using System.Web;
using System.Web.Mvc;
using JustCreativePublishings.Web.Filters;

namespace JustCreativePublishings.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CultureAttribute());
        }
    }
}
