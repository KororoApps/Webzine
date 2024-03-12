namespace Webzine.WebApplication.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RequestLoggingMiddleware"/>.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            // Log request information
            this._logger.LogInformation($"Path through middleware : {context.Request.Path}.");
            this._logger.LogDebug($"Request through middleware : {context.Request.Query}.");

            // Call the next middleware in the pipeline
            await this._next(context);
        }
    }
}