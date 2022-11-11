using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using CMU.Budget.API.Exceptions.HttpExceptions;

namespace CMU.Budget.API.Exceptions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        bool isDevelopment = false;
        private ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(IWebHostEnvironment env, ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
            isDevelopment = env.IsDevelopment();
        }
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;

            if (exception.GetType().BaseType == typeof(HttpException))
            {
                HttpException httpException = (HttpException)exception;
                filterContext.HttpContext.Response.StatusCode = httpException.StatusCode;

                string message = httpException.Message;
                string stackTrace = httpException.StackTrace;

                if (string.IsNullOrEmpty(message))
                {
                    message = filterContext.Exception.Message;
                }

                if (string.IsNullOrEmpty(stackTrace))
                {
                    stackTrace = filterContext.Exception.StackTrace;
                }

                ErrorResponse error = new ErrorResponse(message);
                if (isDevelopment)
                {
                    error.StackTrace = stackTrace;
                }

                _logger.LogError($"{message} : {stackTrace}");

                filterContext.Result = new JsonResult(new
                {
                    errors = new ErrorResponse[] { error },
                });

            }
            else
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string stackTrace = filterContext.Exception.StackTrace;

                _logger.LogError($"{filterContext.Exception.Message} : {stackTrace}");

                filterContext.Result = new JsonResult(new
                {
                    errors = new ErrorResponse[] {
                        new ErrorResponse(filterContext.Exception.Message, isDevelopment ? stackTrace : string.Empty)
                    }
                });
            }

            filterContext.HttpContext.Response.ContentType = "application/json";
        }
    }
}
