using Serilog.Context;

namespace Api.Configuration
{
    public class TraceMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Any(c => c.Key.Equals("x-correlation-id")))
            {
                context.Request.Headers.Add("x-correlation-id", Guid.NewGuid().ToString());
            }

            using (LogContext.PushProperty("CorrelationId", context.Request.Headers.SingleOrDefault(c => c.Key.Equals("x-correlation-id")).Value))
            using (LogContext.PushProperty("Authorization", context.Request.Headers.SingleOrDefault(c => c.Key.Equals("Authorization")).Value))
            {
                await _next(context);
            }
        }
    }
}
