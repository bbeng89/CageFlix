using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CageFlix.ViewModels
{
    public class MoviesViewModel
    {
        public string Search { get; set; }
        public string Order { get; set; }
        public PagedListViewModel<Movie> Movies { get; set; }
    }
}