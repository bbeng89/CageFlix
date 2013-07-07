using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CageFlix.Areas.Admin.ViewModels
{
    public class HomeViewModel
    {
        public PagedListViewModel<Movie> Movies { get; set; }

        public string Search { get; set; }
    }
}