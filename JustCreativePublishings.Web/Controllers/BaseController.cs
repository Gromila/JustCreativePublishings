using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustCreativePublishings.Web.Filters;

namespace JustCreativePublishings.Web.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult ChangeCulture(String lang)
        {
            var returnUrl = Request.UrlReferrer.PathAndQuery;
            var cultures = new List<String>() {"en", "ru"};

            if (!cultures.Contains(lang))
                lang = "en";

            var cookie = Request.Cookies["lang"];

            if (cookie != null)
                cookie.Value = lang;
            else
            {
                cookie = new HttpCookie("lang") {HttpOnly = false, Value = lang, Expires = DateTime.Now.AddYears(1)};
            }

            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult GetCurrentTheme()
        {
            var cookie = Request.Cookies["theme"];

            if (cookie == null || (cookie.Value != "light" && cookie.Value != "dark"))
                cookie = new HttpCookie("theme") {HttpOnly = false, Value = "light", Expires = DateTime.Now.AddYears(1)};

            Response.Cookies.Add(cookie);

            return cookie.Value == "dark" ? Content("~/css/dark") : Content("~/css/light");
        }

        public ActionResult ChangeTheme(String theme)
        {
            var returnUrl = Request.UrlReferrer.PathAndQuery;
            var themes = new List<String>() { "light", "dark" };

            if (!themes.Contains(theme))
                theme = "light";

            var cookie = Request.Cookies["theme"];

            if (cookie != null)
                cookie.Value = theme;
            else
            {
                cookie = new HttpCookie("theme") { HttpOnly = false, Value = theme, Expires = DateTime.Now.AddYears(1) };
            }

            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);                
        }
    }
}