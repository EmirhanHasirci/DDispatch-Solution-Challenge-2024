using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DisasterDispatch.Core.Dtos.BaseDtos
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponse<T> Success(T data, int statusCode)
        {
            return new CustomResponse<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode };
        }
        public static CustomResponse<T> Fail(List<string> errors, int statusCode )
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponse<T> Fail(string error, int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
