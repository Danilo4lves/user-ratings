using Ratings.Models;
using System.Collections.Generic;

namespace Ratings.Repositories.Users
{
    public interface IUserRepository
    {
        bool SaveChanges();

        IEnumerable<User> GetAll();
        User GetById(int id);
        int Create(User user);
        void Delete(int id);
    }
}
