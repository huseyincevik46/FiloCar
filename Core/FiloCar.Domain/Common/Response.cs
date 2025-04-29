using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiloCar.Domain.Common
{

    public class Response<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Message { get; set; }

        public static Response<T> SuccessResponse(T data, string message = null, int statusCode = 200)
        {
            return new Response<T>
            {
                Data = data,
                Success = true,
                StatusCode = statusCode,
                Message = message
            };
        }

        public static Response<T> FailResponse(string error, int statusCode = 400)
        {
            return new Response<T>
            {
                Success = false,
                StatusCode = statusCode,
                Errors = new List<string> { error }
            };
        }

        public static Response<T> FailResponse(IEnumerable<string> errors, int statusCode = 400)
        {
            return new Response<T>
            {
                Success = false,
                StatusCode = statusCode,
                Errors = errors
            };
        }
    }
}
