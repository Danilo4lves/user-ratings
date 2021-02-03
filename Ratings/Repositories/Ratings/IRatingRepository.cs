using Ratings.Models;
using System.Collections.Generic;

namespace Ratings.Repositories.Ratings
{
    public interface IRatingRepository
    {
        bool SaveChanges();

        IEnumerable<Rating> GetById(int id);
        void Create(Rating rating);
    }
}
