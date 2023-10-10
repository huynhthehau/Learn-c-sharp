using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02.middleware.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /**
            Url:"/xxx.html"
            - Khong goi middleware phia sau
            - ban khong duoc truy cap
            - Header - Seconmiddleware: Ban duoc truy cap
            Url: != /xxx.html
            - Header - Serconmiddleware: Ban khong duoc truy cap
            - Chuyen HttpContext cho middleware phia sau
        */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("Secondmiddleware", "Ban khong duoc truy cap");
                var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (dataFromFirstMiddleware != null)
                {
                    await context.Response.WriteAsync((string)dataFromFirstMiddleware);
                }
                await context.Response.WriteAsync("Ban khong duoc truy cap");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Bna duoc truy cap");
                await next(context);
            }
        }
    }
}