using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CageFlix.Models
{
    [Table("Movie")]
    public class Movie
    {
        public Movie()
        {
            this.UserMovies = new HashSet<UserMovie>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Url]
        [Display(Name = "IMDB Link")]
        public string ImdbLink { get; set; }

        [Url]
        [Display(Name = "Rotten Tomatoes Link")]
        public string RottenTomatoesLink { get; set; }

        public virtual ICollection<UserMovie> UserMovies { get; set; }
    }
}