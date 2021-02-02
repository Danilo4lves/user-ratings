using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ratings.Models
{
    public class User
    {
        public User(string name, IEnumerable<Rating> ratings)
        {
            this.Name = name;
            this.Ratings = ratings;
        }

        public User(string name) : this(name, new List<Rating> { }) { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }
    }
}
