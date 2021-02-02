namespace Ratings.Infra
{
    public class SuccessActionResult<DataType> : BaseActionResult<DataType>
    {
        public SuccessActionResult(DataType data) : base(true, data, null) { }
    }
}
