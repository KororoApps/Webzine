public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext context)
    {
        // Log request information
        _logger.LogInformation($"Request: {context.Request.Path} {context.Request.QueryString}");
        _logger.LogInformation("Middleware reached!");

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
