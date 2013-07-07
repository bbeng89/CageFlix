using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CageFlix.Helpers;

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
        [Display(Name = "Thumbnail Image URL")]
        public string ThumnailImageUrl { get; set; }

        [Url]
        [Display(Name = "Profile Image URL")]
        public string ProfileImageUrl { get; set; }

        [Url]
        [Display(Name = "Detailed Image URL")]
        public string DetailedImageUrl { get; set; }

        [Url]
        [Display(Name = "Original Image URL")]
        public string OriginalImageUrl { get; set; }

        [MaxLength(10)]
        [Display(Name = "MPAA Rating")]
        public string MpaaRating { get; set; }

        [Display(Name = "Runtime")]
        public int? Runtime { get; set; }

        [MaxLength(5000)]
        [Display(Name = "Critics Consensus")]
        public string CriticsConsensus { get; set; }

        [MaxLength(5000)]
        [Display(Name = "Synopsis")]
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

        // Custom methods/properties
        public string AuthenticatedRottenTomatoesUrl
        {
            get { return String.Format("{0}?apikey={1}", this.RottenTomatoesApiUrl, RottenTomatoesHelpers.ApiKey); }
        }
    }
}