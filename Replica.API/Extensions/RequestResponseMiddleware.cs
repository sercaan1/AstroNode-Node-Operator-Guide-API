using Business.Abstracts;
using System.Text;

namespace Replica.API.Extensions
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;

        public RequestResponseMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await LogRequest(httpContext);

            var originalResponseBody = httpContext.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                httpContext.Response.Body = responseBody;
                await _next.Invoke(httpContext);

                await LogResponse(httpContext, responseBody, originalResponseBody);
            }
        }

        private async Task LogResponse(HttpContext httpContext, MemoryStream responseBody, Stream originalResponseBody)
        {
            var responseContent = new StringBuilder();
            responseContent.AppendLine("=== Response Info ===");

            responseContent.AppendLine("-- headers");
            foreach (var (headerKey, headerValue) in httpContext.Response.Headers)
            {
                responseContent.AppendLine($"header = {headerKey}    value = {headerValue}");
            }

            responseContent.AppendLine("-- body");
            responseBody.Position = 0;
            var content = await new StreamReader(responseBody).ReadToEndAsync();
            responseContent.AppendLine($"body = {content}");
            responseBody.Position = 0;
            await responseBody.CopyToAsync(originalResponseBody);
            httpContext.Response.Body = originalResponseBody;

            _logger.LogInfo(responseContent.ToString());
        }

        private async Task LogRequest(HttpContext httpContext)
        {
            var requestContent = new StringBuilder();

            requestContent.AppendLine("=== Request Info ===");
            requestContent.AppendLine($"method = {httpContext.Request.Method.ToUpper()}");
            requestContent.AppendLine($"path = {httpContext.Request.Path}");

            requestContent.AppendLine("-- headers");
            foreach (var (headerKey, headerValue) in httpContext.Request.Headers)
            {
                requestContent.AppendLine($"header = {headerKey}    value = {headerValue}");
            }

            requestContent.AppendLine("-- body");
            httpContext.Request.EnableBuffering();
            var requestReader = new StreamReader(httpContext.Request.Body);
            var content = await requestReader.ReadToEndAsync();
            requestContent.AppendLine($"body = {content}");

            _logger.LogInfo(requestContent.ToString());
            httpContext.Request.Body.Position = 0;
        }
    }
}
