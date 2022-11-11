using System;
using System.Net;

namespace CMU.Budget.API.Exceptions
{
    namespace HttpExceptions
    {
        public abstract class HttpException : Exception
        {
            public abstract int StatusCode { get; }
        }

        public class CustomHttpException : HttpException
        {
            public override int StatusCode { get; }
            public override string Message { get; }

            public CustomHttpException(HttpStatusCode statusCode, string message)
            {
                StatusCode = (int)statusCode;
                Message = message;
            }
        }

        public class HttpBadRequestException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.BadRequest; } }
            public override string Message { get; }

            public HttpBadRequestException()
            {
                Message = "Bad Request";
            }
            public HttpBadRequestException(string message)
            {
                Message = message;
            }
        }

        public class HttpMethodNotAllowedException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.MethodNotAllowed; } }
            public override string Message { get; }

            public HttpMethodNotAllowedException()
            {
                Message = "Method not allowed";
            }
            public HttpMethodNotAllowedException(string message)
            {
                Message = message;
            }
        }

        public class HttpNotFoundException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.NotFound; } }
            public override string Message { get; }

            public HttpNotFoundException()
            {
                Message = "Request Error";
            }
            public HttpNotFoundException(string message)
            {
                Message = message;
            }
        }

        public class HttpInternalServerErrorException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.InternalServerError; } }
            public override string Message { get; }
            public HttpInternalServerErrorException()
            {

            }
            public HttpInternalServerErrorException(string message)
            {
                Message = message;
            }
        }

        public class UnauthorizedException : HttpException
        {
            public override int StatusCode { get { return (int)HttpStatusCode.Unauthorized; } }
            public override string Message { get; }

            public UnauthorizedException()
            {
                Message = "Unauthorized";
            }
            public UnauthorizedException(string message)
            {
                Message = message;
            }
        }
    }
}
