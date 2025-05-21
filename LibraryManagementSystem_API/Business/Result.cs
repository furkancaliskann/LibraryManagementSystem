using System.Text.Json.Serialization;

namespace Business
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        
        [JsonIgnore]
        public ResultCodes StatusCode { get; set; }
        
        public T? Data { get; set; }


        public static Result<T> SuccessResult()
        {
            return new Result<T> { IsSuccess = true, ErrorMessage = string.Empty, StatusCode = ResultCodes.NoContent, Data = default };
        }

        public static Result<T> SuccessResultWithData(T data)
        {
            return new Result<T> { IsSuccess = true, ErrorMessage = string.Empty, StatusCode = ResultCodes.Ok, Data = data };
        }

        public static Result<T> FailedResult(string errorMessage, ResultCodes statusCode)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage, StatusCode = statusCode, Data = default };
        }
    }

    public enum ResultCodes
    {
        //Success
        Ok,
        NoContent,

        //Error
        ServerError,
        BadRequest,
        NotFound,
        Conflict,
        Forbidden,
        Unauthorized
    }
}
