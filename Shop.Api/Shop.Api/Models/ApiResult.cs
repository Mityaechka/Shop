namespace Shop.Api.Models
{
    public class ApiResult
    {
        public bool IsError { get; set; }

        public static ApiResult Success()
        {
            return new ApiResult { IsError = false };
        }

        public static ApiResult Error()
        {
            return new ApiResult { IsError = true };
        }



    }
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }

        public static new ApiResult<T> Error()
        {
            return new ApiResult<T> { IsError = true };
        }
    }
}
