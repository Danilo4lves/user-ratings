namespace Ratings.Infra
{
    public class BaseActionResult<DataType>
    {
        public BaseActionResult(bool ok, DataType data, ResponseError error)
        {
            this.Ok = ok;
            this.Data = data;
            this.Error = error;
        }

        public BaseActionResult(bool ok, DataType data, int code, string message) : this(ok, data, new ResponseError(code, message)) { }

        public bool Ok { get; set; }
        public dynamic Data { get; set; }
        public ResponseError Error { get; set; }

    }
}
