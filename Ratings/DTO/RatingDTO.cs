using System;

namespace Ratings
{
    public abstract class BaseRatingDTO
    {
        public BaseRatingDTO(int userId, string mood, string platform, string appVersion, string feedback)
        {
            UserId = userId;
            Mood = mood;
            Platform = platform;
            AppVersion = appVersion;
            Feedback = feedback;
        }

        public int UserId { get; set; }
        public string Mood { get; set; }
        public string Platform { get; set; }
        public string AppVersion { get; set; }
        public string Feedback { get; set; } = null;
    }

    public class ReadRatingDTO : BaseRatingDTO
    {
        public ReadRatingDTO(int userId, string mood, string platform, string appVersion, string feedback, DateTime reviewDate)
            : base(userId, mood, platform, appVersion, feedback)
        {
            ReviewDate = reviewDate;
        }

        public DateTime ReviewDate { get; set; }
    }

    public class CreateRatingDTO : BaseRatingDTO
    {
        public CreateRatingDTO(int userId, string mood, string platform, string appVersion, string feedback)
            : base(userId, mood, platform, appVersion, feedback)
        {
        }
    }
}
