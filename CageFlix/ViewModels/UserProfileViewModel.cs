using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CageFlix.Models;

namespace CageFlix.ViewModels
{
    public class UserProfileViewModel : PagedListViewModel<UserMovie>
    {
        public UserProfile User { get; private set; }

        public UserProfileViewModel(UserProfile user, IQueryable<UserMovie> movies, int? page) 
            : base(movies, page)
        {
            this.User = user;
        }
    }
}