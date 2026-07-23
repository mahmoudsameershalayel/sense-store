using Sense.Domain.DBEntities.ErrorModels;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Sense.Infrastructure.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var exception = contextFeature.Error;
                        var statusCode = StatusCodes.Status500InternalServerError;
                        var resultCodeStatus = ResultCodeStatus.Failed;

                        var errorMessage = contextFeature.Error.Message;
                        var errorResponse = ResponseResult<object>.GetResult(
                           ResultCodeStatus.BadRequest,  // or another enum value that indicates error
                           errorMessage
                       );

                        switch (exception)
                        {
                            case UnauthorizedAccessException:
                                statusCode = StatusCodes.Status401Unauthorized;
                                resultCodeStatus = ResultCodeStatus.UnAuthorized;
                                break;
                            case KeyNotFoundException:
                                statusCode = StatusCodes.Status404NotFound;
                                resultCodeStatus = ResultCodeStatus.NotFound;
                                break;
                            case ArgumentException:
                            case ValidationException:
                                statusCode = StatusCodes.Status400BadRequest;
                                resultCodeStatus = ResultCodeStatus.BadRequest;
                                break;
                            // Add more custom exception mappings here
                            default:
                                statusCode = StatusCodes.Status500InternalServerError;
                                resultCodeStatus = ResultCodeStatus.Failed;
                                break;
                        }

                        var json = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });

                        await context.Response.WriteAsync(json);

                    }
                });
            });
        }
    }
}
