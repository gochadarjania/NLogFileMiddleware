using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLogFile.Middleware
{
    public class LoggerMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                _logger.LogError("Performing file logging in Middleware operation");

                // Perform some Database action into Middleware 


                _logger.LogWarning("Performing Middleware Save operation");

                //Save Data


                _logger.LogInformation("Save Comepleted");

                await _next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
            }
        }
    }
}
