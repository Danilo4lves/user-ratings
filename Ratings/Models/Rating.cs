using System;
using System.ComponentModel.DataAnnotations;

namespace Ratings.Models
{
    public class Rating
    {
        public Rating(int userId, string mood, string platform, string appVersion, string feedback = null)
        {
            this.UserId = userId;
            this.Mood = mood;
            this.Platform = platform;
            this.AppVersion = appVersion;
            this.Feedback = feedback;
            this.ReviewDate = DateTime.Now;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Mood { get; set; }

        [Required]
        public string Platform { get; set; }

        [Required]
        public string AppVersion { get; set; }

        public string Feedback { get; set; }

        public DateTime ReviewDate { get; set; }

    }
}
