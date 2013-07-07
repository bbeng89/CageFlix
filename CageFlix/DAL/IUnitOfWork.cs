using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CageFlix.Models;

namespace CageFlix.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<UserProfile> UserProfileRepository { get; }
        IGenericRepository<Movie> MovieRepository { get; }
        IGenericRepository<UserMovie> UserMovieRepository { get; }

        void Save();
    }
}
