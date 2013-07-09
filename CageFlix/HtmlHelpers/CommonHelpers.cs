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

        public static IHtmlString BootstrapPager<T>(this HtmlHelper helper, PagedListViewModel<T> model) where T : class
        {
            return helper.Pager(model.Objects.PageSize, model.Objects.PageNumber, model.Objects.TotalItemCount).Options(o => o
                .DisplayTemplate("BootstrapPagination")
                .MaxNrOfPages(5)
                .AlwaysAddFirstPageNumber());
        }

        public static string CageFlixRatingClass(this HtmlHelper helper, int cageRating)
        {
            return helper.CageFlixRatingClass(Convert.ToDouble(cageRating));
        }

        //TODO: it would be nice if this would just generate the HTML element for you - possibly pass in the element type (e.g. "h2", "p", etc)
        public static string CageFlixRatingClass(this HtmlHelper helper, double cageRating)
        {
            if (cageRating >= 3 && cageRating <= 5)
                return "text-success";
            else if (cageRating > 5 && cageRating <= 8)
                return "text-warning";
            else if (cageRating > 8 && cageRating <= 11)
                return "text-error";
            else
                return "";
        }
    }
}