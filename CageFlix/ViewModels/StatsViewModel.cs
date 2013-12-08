using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CageFlix.ViewModels
{
    public class StatsViewModel : Controller
    {
        public Movie LowestRated { get; set; }
        public Movie HighestRated { get; set; }
    }
}