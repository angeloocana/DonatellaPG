using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DonatellaAdmin.Helpers
{
    public static class BootStrapHelpers
    {
        public static IHtmlString BootStrapLabelFor<TModel, TProp>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProp>> property)
        {
            return helper.LabelFor(property, new { @class = "col-md-2 control-label" });
        }

        public static IHtmlString BootStrapLabel(
            this HtmlHelper helper,
            string propertyName)
        {
            return helper.Label(propertyName, new { @class = "col-md-2 control-label" });
        }
    }
}