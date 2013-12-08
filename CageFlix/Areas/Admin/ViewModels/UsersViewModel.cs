using CageFlix.Models;
using CageFlix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CageFlix.Areas.Admin.ViewModels
{
    public class UsersViewModel
    {
        public PagedListViewModel<UserProfile> Users { get; set; }

        public string Search { get; set; }
    }
}