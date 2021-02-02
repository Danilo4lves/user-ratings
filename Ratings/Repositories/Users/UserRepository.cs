using Ratings.Data;
using Ratings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ratings.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        public int Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

           _context.Users.Add(user);

            this.SaveChanges();

            return user.Id;
        }

        public User GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(user => user.Id == id);

            return user;
        }

        public void Delete(int id)
        {
            var user = this.GetById(id);

            _context.Users.Remove(user);

            this.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public bool SaveChanges()
        {
            int totalRowsAffected = _context.SaveChanges();

            return totalRowsAffected > 0;
        }
    }
}
