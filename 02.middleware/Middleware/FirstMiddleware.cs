namespace _02.middleware.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        // RequestDelegate ~ async (HttpContext context)=> {}
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(context.Request.Path);
            context.Items.Add("DataFirstMiddleware", $"{context.Request.Path}First middleware");
            // await context.Response.WriteAsync("First middleware");
            await _next(context);
        }
    }
}