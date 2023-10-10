using _02.middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); // Thêm dịch vụ dùng bộ nhớ lưu cache (session sử dụng dịch vụ này)
builder.Services.AddSession(); // Thêm  dịch vụ Session, dịch vụ này cunng cấp Middleware:
builder.Services.AddSingleton<SecondMiddleware>();

var app = builder.Build();
{
    app.UseFirstMiddleware();
    app.UseSecondMiddleware();
    // Thêm StaticFileMiddleware - nếu Request là yêu cầu truy cập file tĩnh,
    // Nó trả ngay về Response nội dung file và là điểm cuối pipeline, nếu khác
    // nó gọi  Middleware phía sau trong Pipeline
    app.UseStaticFiles();

    // Thêm SessionMiddleware:  khôi phục, thiết lập - tạo ra session
    // gán context.Session, sau đó chuyển gọi ngay middleware
    // tiếp trong pipeline
    app.UseSession();

    // Thêm EndpointRoutingMiddleware: ánh xạ Request gọi đến Endpoint (Middleware cuối)
    // phù hợp định nghĩa bởi EndpointMiddleware
    app.UseRouting();

    // app.UseEndpoint dùng để xây dựng các endpoint - điểm cuối  của pipeline theo Url truy cập
    app.UseEndpoints(endpoints =>
    {

        // EndPoint(2) khi truy vấn đến /Testpost với phương thức post hoặc put
        endpoints.MapMethods("/Testpost", new string[] { "post", "put" }, async context =>
        {
            await context.Response.WriteAsync("post/pust");
        });

        //  EndPoint(2) -  Middleware khi truy cập /Home với phương thức GET - nó làm Middleware cuối Pipeline
        endpoints.MapGet("/Home", async context =>
        {

            int? count = context.Session.GetInt32("count");
            count = (count != null) ? count + 1 : 1;
            context.Session.SetInt32("count", count.Value);
            await context.Response.WriteAsync($"Home page! {count}");

        });
    });
    app.Map("/admin", (app1) =>
    {
        // tao middleware cua nhanh
        app1.UseRouting();

        // app.UseEndpoint dùng để xây dựng các endpoint - điểm cuối  của pipeline theo Url truy cập
        app1.UseEndpoints(endpoints =>
        {
            //  EndPoint(2) -  Middleware khi truy cập /Home với phương thức GET - nó làm Middleware cuối Pipeline
            endpoints.MapGet("/admin2", async context =>
            {
                await context.Response.WriteAsync($"Home page 2");
            });
        });
        //M2
        app1.Run(async (context) =>
        {
            await context.Response.WriteAsync("Xin chao day la m2");
        });
    });
    app.Run(async context =>
    {
        // context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync("Page not found");
    });
    app.Run();
    // EndPoint(3)  app.Run tham số là hàm delegate tham số là HttpContex
    // - nó tạo điểm cuối của pipeline.


}