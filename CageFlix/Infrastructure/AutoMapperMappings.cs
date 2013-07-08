using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CageFlix.Models;

namespace CageFlix.Infrastructure
{
    public static class AutoMapperMappings
    {
        public static void CreateMaps()
        {
            AutoMapper.Mapper.CreateMap<Movie, Movie>().ForMember(m => m.UserMovies, opt => opt.Ignore());
        }
    }
}