namespace Ratings.Infra
{
    public class ErrorActionResult : BaseActionResult<object>
    {
        public ErrorActionResult(int code, string message) : base(true, null, code, message) { }

        public ErrorActionResult(ResponseError error) : base(true, null, error) { }
    }
}
