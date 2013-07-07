using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CageFlix.Models;

namespace CageFlix.DAL
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private CageFlixContext context = new CageFlixContext();
        private EfGenericRepository<UserProfile> userRepo;
        private EfGenericRepository<Movie> movieRepo;
        private EfGenericRepository<UserMovie> userMovieRepo;
        private bool disposed = false;

        public IGenericRepository<UserProfile> UserProfileRepository
        {
            get
            {

                if (this.userRepo == null)
                {
                    this.userRepo = new EfGenericRepository<UserProfile>(context);
                }
                return userRepo;
            }
        }

        public IGenericRepository<Movie> MovieRepository
        {
            get
            {

                if (this.movieRepo == null)
                {
                    this.movieRepo = new EfGenericRepository<Movie>(context);
                }
                return movieRepo;
            }
        }

        public IGenericRepository<UserMovie> UserMovieRepository
        {
            get
            {

                if (this.userMovieRepo == null)
                {
                    this.userMovieRepo = new EfGenericRepository<UserMovie>(context);
                }
                return userMovieRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}