namespace Ratings.DTO
{
    public abstract class BaseUserDTO
    {
        public string Name { get; set; }
    }

    public class CreateUserDTO : BaseUserDTO { }

    public class ReadUserDTO : BaseUserDTO
    {
        public int Id { get; set; }
    }
}
