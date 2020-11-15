using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;

namespace TravelTeam.Web.Infrastructure.Middlewares
{
    /// <summary>
    /// API exception middleware.
    /// </summary>
    public class ApiExceptionMiddleware
    {
        private const string ErrorsKey = "errors";

        private readonly RequestDelegate next;
        private readonly ILogger<ApiExceptionMiddleware> logger;
        private readonly IWebHostEnvironment environment;
        private readonly string problemJsonMimeType = @"application/problem+json";

        private static readonly IDictionary<Type, int> exceptionStatusCodes = new Dictionary<Type, int>
        {
            [typeof(NotFoundException)] = StatusCodes.Status404NotFound,
            [typeof(NotImplementedException)] = StatusCodes.Status501NotImplemented,
            [typeof(ForbiddenException)] = StatusCodes.Status403Forbidden,
            [typeof(UnauthorizedException)] = StatusCodes.Status401Unauthorized,
            [typeof(DomainException)] = StatusCodes.Status400BadRequest,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionMiddleware" /> class.
        /// </summary>
        public ApiExceptionMiddleware(
            RequestDelegate next,
            ILogger<ApiExceptionMiddleware> logger,
            IWebHostEnvironment environment)
        {
            this.next = next;
            this.logger = logger;
            this.environment = environment;
        }

        /// <summary>
        /// Invokes the next middleware.
        /// </summary>
        /// <param name="httpContext">HTTP context.</param>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception exception)
            {
                if (httpContext.Response.HasStarted)
                {
                    logger.LogWarning(
                        "The response has already started, the API exception middleware will not be executed.");
                    throw;
                }
                var problemDetails = GetObjectByException(exception);
                problemDetails.Instance = httpContext.Request.Path;
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = problemJsonMimeType;

                var serialized = JsonConvert.SerializeObject(problemDetails);
                await httpContext.Response.WriteAsync(serialized, httpContext.RequestAborted);
            }
        }

        private ValidationProblemDetails GetObjectByException(Exception exception)
        {
            // Prepare model.
            var problem = new ValidationProblemDetails();
            var statusCode = StatusCodes.Status400BadRequest;
            problem.Extensions[ErrorsKey] = Enumerable.Empty<ProblemFieldDto>();
            switch (exception)
            {
                case ValidationException validationException:
                    problem.Extensions[ErrorsKey] = validationException.Errors.Select(
                        e => new ProblemFieldDto(e.Key, e.Value));
                    AddExceptionInfoToProblemDetails(problem, validationException);
                    break;
                case DomainException domainException:
                    AddExceptionInfoToProblemDetails(problem, domainException);
                    statusCode = GetStatusCodeByExceptionType(domainException.GetType());
                    break;
                default:
                    problem.Title = "Internal server error.";
                    if (!environment.IsProduction())
                    {
                        problem.Extensions["debug"] = exception;
                    }
                    statusCode = StatusCodes.Status500InternalServerError;
                    logger.LogError(exception, exception.Message);
                    break;
            }
            problem.Status = statusCode;
            return problem;
        }

        private static void AddExceptionInfoToProblemDetails(ProblemDetails problemDetails, DomainException exception)
        {
            problemDetails.Title = exception.Message;
            problemDetails.Type = exception.GetType().Name;
        }

        private static int GetStatusCodeByExceptionType(Type exceptionType)
        {
            // Most probable case.
            if (exceptionType == typeof(DomainException))
            {
                return StatusCodes.Status400BadRequest;
            }
            foreach ((Type exceptionTypeKey, int statusCode) in exceptionStatusCodes)
            {
                if (exceptionTypeKey.IsAssignableFrom(exceptionType))
                {
                    return statusCode;
                }
            }
            return StatusCodes.Status500InternalServerError;
        }
    }
}
