using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CageFlix.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            this.UserMovies = new HashSet<UserMovie>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<UserMovie> UserMovies { get; set; }
    }
}