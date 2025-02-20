﻿namespace EFCodeFirst.DTO
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Success", int statusCode = 200)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Message = message, Data = data };
        }

        public static ApiResponse<T> Error(string message, int statusCode = 500)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Message = message, Data = default };
        }
    }
}
