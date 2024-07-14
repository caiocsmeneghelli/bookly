using Bookly.Application.Validations.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(ex, httpContext);
            }
        }

        private async Task HandleException(Exception ex, HttpContext httpContext)
        {
            if(ex is BadRequestException bad)
            {
                httpContext.Response.StatusCode = 400;

                var problemDetails = new ProblemDetails();
                problemDetails.Title = "BadRequest";
                problemDetails.Detail = ex.Message;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6problemDetails..5.1";
                problemDetails.Extensions.Add("errors", bad.Errors);

                await httpContext.Response.WriteAsJsonAsync(problemDetails);
            }
            else
            {
                httpContext.Response.StatusCode = 400;

                var problemDetails = new ProblemDetails();
                problemDetails.Title = "BadRequest";
                problemDetails.Detail = ex.Message;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6problemDetails..5.1";
                problemDetails.Extensions.Add("data", ex.Data);

                await httpContext.Response.WriteAsJsonAsync(problemDetails);
            }

            //if (ex is InvalidOperationException)
            //{
            //    httpContext.Response.StatusCode = 400; //HTTP status code
            //                                           //httpContext.Response.WriteAsync("Invalid operation");
            //                                           //httpContext.Response.WriteAsync("Invalid operation");             
            //    await httpContext.Response.WriteAsJsonAsync(new ResponseModelException
            //    {
            //        Message = "Invalid operation",
            //        StatusCode = 400,
            //        Success = false
            //    });
            //}
            //else if (ex is ArgumentException)
            //{
            //    await httpContext.Response.WriteAsync("Invalid argument");
            //}
            //else
            //{
            //    await httpContext.Response.WriteAsync("Unknown error");
            //}


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
