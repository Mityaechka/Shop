namespace Shop.Api.Models
{
    public class ApiResult
    {
        public int ErrorCode { get; set; }
    }
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
        
    }
}
