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

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Display(Name = "Year Released")]
        public int? ReleaseYear { get; set; }

        [Url]
        public string ThumnailImageUrl { get; set; }

        [Url]
        public string ProfileImageUrl { get; set; }

        [Url]
        public string DetailedImageUrl { get; set; }

        [Url]
        public string OriginalImageUrl { get; set; }

        [MaxLength(10)]
        public string MpaaRating { get; set; }

        public int? Runtime { get; set; }

        [MaxLength(5000)]
        public string CriticsConsensus { get; set; }

        [MaxLength(5000)]
        public string Synopsis { get; set; }

        //External Links

        [Url]
        [Display(Name = "Rotten Tomatoes API Url")]
        public string RottenTomatoesApiUrl { get; set; }

        [Url]
        [Display(Name = "IMDB Link")]
        public string ImdbLink { get; set; }

        [Url]
        [Display(Name = "Rotten Tomatoes Link")]
        public string RottenTomatoesLink { get; set; }

        [Url]
        [Display(Name = "Netflix Link")]
        public string NetflixLink { get; set; }

        public virtual ICollection<UserMovie> UserMovies { get; set; }
    }
}