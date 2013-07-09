using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CageFlix.Models;

namespace CageFlix.ViewModels
{
    public class UserProfileViewModel
    {
        public UserProfile User { get; private set; }

        public List<UserMovie> RecentUserMovies { get; private set; }

        public UserProfileViewModel(UserProfile user)
        {
            this.User = user;
            this.RecentUserMovies = this.User.UserMovies.Take(5).ToList();
        }
    }
}