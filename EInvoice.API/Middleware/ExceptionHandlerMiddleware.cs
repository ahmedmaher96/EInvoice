using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;

namespace EInvoice.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        #region Private Attributes

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        #endregion

        #region Constructors

        public ExceptionHandlerMiddleware(
            ILogger<ExceptionHandlerMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        #endregion

        #region Methods

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "error during executing {Context}", context.Request.Path.Value);
                var response = context.Response;
                response.ContentType = "application/json";
                
                var (status, message) = GetResponse(exception);
                response.StatusCode = (int)status;
                await response.WriteAsync(message);
            }
        }

        public (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case KeyNotFoundException
                    or FileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            return (code, JsonConvert.SerializeObject(new SimpleResponse(exception.Message)));
        }

        #endregion

        #region Helper Classes

        public class SimpleResponse
        {
            public string Message { get; set; }
            public SimpleResponse(string message)
            {
                Message = message;
            }
        }

        #endregion
    }
}

