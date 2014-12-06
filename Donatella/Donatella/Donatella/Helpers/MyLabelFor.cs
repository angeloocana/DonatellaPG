using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Donatella.Helpers
{
    public static class MyLabelForExtenssion
    {
        public static MvcHtmlString MyLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return MyLabelFor<TModel, TValue>(html, expression, null);
        }

        public static MvcHtmlString MyLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return MyLabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString MyLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (String.IsNullOrEmpty(labelText))
                return MvcHtmlString.Empty;

            var tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            var span = new TagBuilder("span");
            span.Attributes.Add("class", "required");
            span.SetInnerText("*");

            tag.InnerHtml = labelText + (metadata.IsRequired ? span.ToString(TagRenderMode.Normal) : "");

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}