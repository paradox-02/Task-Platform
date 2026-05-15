namespace TaskPlatform.Common
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = "success")
        {
            return new ApiResponse<T>
            {
                Code = 200,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Fail(string message = "fail", int code = 500)
        {
            return new ApiResponse<T>
            {
                Code = code,
                Message = message,
                Data = default
            };
        }
    }
}
