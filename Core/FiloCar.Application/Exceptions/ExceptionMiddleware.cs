using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Application.Features.Drivers.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;

namespace FiloCar.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu."); // Hataları burada logluyoruz
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;


            if (exception is ValidationException validationException)
            {
                await httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = validationException.Errors.Select(e => e.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
                return;
            }

            // Özel exception sınıflarını da burada kontrol edebiliriz
            if (exception is DriverException driverException)
            {
                await httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = new List<string> { $"Driver Error: {driverException.Message}" },
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
                return;
            }

            if (exception is NotFoundException notFoundException)
            {
                await httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = new List<string> { $"Not Found Error: {notFoundException.Message}" },
                    StatusCode = StatusCodes.Status404NotFound
                }.ToString());
                return;
            }

            List<string> errors = new()
            {
                $"Hata Mesajı : {exception.Message}"
            };


            await httpContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
