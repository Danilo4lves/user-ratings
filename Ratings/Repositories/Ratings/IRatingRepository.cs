using Ratings.Models;
using System;
using System.Collections.Generic;

namespace Ratings.Repositories.Ratings
{
    public interface IRatingRepository : IDisposable
    {
        bool SaveChanges();

        IEnumerable<Rating> GetById(int id);
        void Create(Rating rating);
    }
}
