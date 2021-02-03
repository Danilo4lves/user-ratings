using Ratings.Data;
using Ratings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ratings.Repositories.Ratings
{
    public class RatingRepository : IRatingRepository
    {
        private UsersContext _context;

        public RatingRepository(UsersContext context)
        {
            _context = context;
        }

        public void Create(Rating rating)
        {

            _context.Ratings.Add(rating);

            this.SaveChanges();
        }

        public IEnumerable<Rating> GetById(int id)
        {
            var ratings = _context.Ratings.Where(rating => rating.UserId == id);

            return ratings;
        }

        public bool SaveChanges()
        {
            int totalRowsAffected = _context.SaveChanges();

            return totalRowsAffected > 0;
        }
    }
}
