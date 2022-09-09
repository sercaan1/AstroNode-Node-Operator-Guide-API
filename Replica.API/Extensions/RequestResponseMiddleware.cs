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
            var originalBodyStream = httpContext.Response.Body;

            var request = await GetRequestAsTextAsync(httpContext.Request);

            _logger.LogInfo(request);

            await using var responseBody = new MemoryStream();
            httpContext.Response.Body = responseBody;

            await _next.Invoke(httpContext);

            var response = await GetResponseAsTextAsync(httpContext.Response);

            _logger.LogInfo(response);

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<string> GetResponseAsTextAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return text;
        }

        private async Task<string> GetRequestAsTextAsync(HttpRequest request)
        {
            var body = request.Body;

            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            return $"{request.Scheme} {request.Host} {request.Path} {request.QueryString} {bodyAsText}";
        }
    }
}
