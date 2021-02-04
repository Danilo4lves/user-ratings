using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ratings.Models
{
    public class User
    {
        public User(string name)
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
