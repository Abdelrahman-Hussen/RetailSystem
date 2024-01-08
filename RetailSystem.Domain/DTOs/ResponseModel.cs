using System.Net;

namespace RetailSystem.Domain.DTOs
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public bool Ok { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ResponseModel<T> Success(T data)
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = data,
                Ok = true,
                Message = "success",
            };
        }

        public static ResponseModel<T> Success(string message = "success")
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = default(T),
                Ok = true,
                Message = message,
            };
        }

        public static ResponseModel<T> Success(string message, T data)
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = data,
                Ok = true,
                Message = message,
            };
        }

        public static ResponseModel<T> ErrorNotFound(string message = "Item Not Found")
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Data = default(T),
                Ok = false,
                Message = message
            };
        }

        public static ResponseModel<T> ErrorBadRequset(string message = "an error occured")
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Data = default(T),
                Ok = false,
                Message = message
            };
        }

        public static ResponseModel<T> Error(string message = "an error occured",
                                            HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)statusCode,
                Data = default(T),
                Ok = false,
                Message = message
            };
        }

        public static ResponseModel<T> Error(T data)
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Data = data,
                Ok = false,
                Message = "an error occured",
            };
        }

        public static ResponseModel<T> Error(string message, T data)
        {
            return new ResponseModel<T>
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Data = data,
                Ok = false,
                Message = message
            };
        }
    }
}