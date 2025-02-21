namespace EShopPro.Domain.Common
{

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; } 
        public List<string> Errors { get; set; }
        public string? Message { get; set; }

        public ApiResponse() => Errors = new List<string>();

        // Constructor for successful response with data
        public ApiResponse(T data, string message = "")
        {
            Success = true;
            Data = data;
            Message = message;
            Errors = new List<string>();
        }

        // Constructor for failure response with errors
        public ApiResponse(List<string> errors, string message = "")
        {
            Success = false;
            Errors = errors ?? new List<string>();
            Message = message;
            Data = default;
        }

        // Constructor for failure response with single error
        public ApiResponse(string error, string message = "")
        {
            Success = false;
            Errors = new List<string> { error };
            Message = message;
            Data = default;
        }
    }


}
