using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ploomes.API.Business.Exceptions;
using Ploomes.API.Cross.Query;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Ploomes.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException)
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            else if (exception is ForeignKeyViolationException)
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            else if (exception is ValidateException)
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            else
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ResultQuery { Message = exception.Message }));
        }
    }
}
