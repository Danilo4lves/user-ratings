namespace Ratings.Infra
{
    public class ResponseError
    {
        public ResponseError(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public ResponseError(int code) : this(code, null) { }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
