using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace JustCreativePublishings.Web.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            String cultureName = null;
            HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];

            cultureName = cultureCookie != null ? cultureCookie.Value : "en";

            var cultures = new List<String>() { "en", "ru" };

            if (!cultures.Contains(cultureName))
                cultureName = "en";

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}