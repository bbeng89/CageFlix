using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MvcPaging;
using CageFlix.ViewModels;

namespace CageFlix.HtmlHelpers
{
    public static class CommonHelpers
    {
        public static string Pluralize(this HtmlHelper helper, int count, string singular, string plural = null)
        {
            if (count == 1)
            {
                return singular;
            }
            else
            {
                if (plural != null)
                {
                    return plural;
                }
                else
                {
                    //if the user didn't specify a plural try to guess it
                    if (singular.EndsWith("y"))
                        return singular.Replace("y", "ies");
                    else
                        return singular + "s";
                }
            }
        }

        public static MvcHtmlString BootstrapPager<T>(this HtmlHelper helper, PagedListViewModel<T> model) where T : class
        {
            var pager = helper.Pager(model.Objects.PageSize, model.Objects.PageNumber, model.Objects.TotalItemCount).Options(o => o
                .DisplayTemplate("BootstrapPagination")
                .MaxNrOfPages(5)
                .AlwaysAddFirstPageNumber());
            return MvcHtmlString.Create(pager.ToHtmlString());
        }
    }
}