using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CageFlix.Models;
using System.Net;
using System.Web.Helpers;

namespace CageFlix.Helpers
{
    public static class RottenTomatoesHelpers
    {
        public static string BaseUrl
        {
            get { return "http://api.rottentomatoes.com/api/public/v1.0/movies"; }
        }

        public static string ApiKey
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["RottenTomatoesApiKey"]); }
        }

        public static Movie UpdateMovie(Movie movie)
        {
            if (movie.RottenTomatoesApiUrl != null)
            {
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(movie.AuthenticatedRottenTomatoesUrl);
                    var obj = Json.Decode(json);
                    movie.Title = obj.title;
                    movie.ReleaseYear = obj.year;
                    movie.MpaaRating = obj.mpaa_rating;
                    movie.Runtime = obj.runtime;
                    movie.CriticsConsensus = obj.critics_consensus;
                    movie.Synopsis = obj.synopsis;
                    movie.ThumnailImageUrl = obj.posters.thumbnail ;
                    movie.ProfileImageUrl = obj.posters.profile;
                    movie.DetailedImageUrl = obj.posters.detailed;
                    movie.OriginalImageUrl = obj.posters.original;
                    movie.RottenTomatoesLink = obj.links.alternate;
                    if (obj.alternate_ids != null && obj.alternate_ids.imdb != null)
                    {
                        movie.ImdbLink = "http://www.imdb.com/title/tt" + obj.alternate_ids.imdb;
                    }
                }
            }
            return movie;
        }
    }
}