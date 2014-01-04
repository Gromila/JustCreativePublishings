using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace JustCreativePublishings.Web.Helpers
{
    public static class DatePickerHelper
    {
        public static MvcHtmlString DatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            var text = html.TextBoxFor(expression, new { type = "text", id = "datepicker", @class = "date form-control" }).ToString();
            return MvcHtmlString.Create(text);
        }
    }
}