using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Domain.Models;

namespace JobAssignmentSplititExam.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidDataException ex)
            {
                await HandleInvalidDataExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleGeneralExceptionAsync(context, ex);
            }
        }

        private static Task HandleInvalidDataExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NoContent;

            var result = JsonConvert.SerializeObject(new ErrorDetail
            {
                Code = context.Response.StatusCode.ToString(),
                Message = exception.Message
            });

            return context.Response.WriteAsync(result);
        }

        private static Task HandleGeneralExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new ErrorDetail
            {
                Code = context.Response.StatusCode.ToString(),
                Message = "An unexpected error occurred!"
            });

            return context.Response.WriteAsync(result);
        }
    }
}
