var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{

    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Trang chủ");
    });

    endpoints.Map("/RequestInfo", async context =>
    {
        await context.Response.WriteAsync("/RequestInfo");
    });

    endpoints.MapGet("/Encoding", async context =>
    {
        await context.Response.WriteAsync("/Encoding");
    });

    endpoints.MapGet("/Cookies/{*action}", async context =>
    {
        await context.Response.WriteAsync("/Cookies");
    });

});
// Điểm rẽ nhánh pipeline khi URL là /Json
app.Map("/Json", app =>
{
    app.Run(async context =>
    {
        // code ở đây
        await context.Response.WriteAsync("/Json");
    });
});

// Điểm rẽ nhánh pipeline khi URL là /Form
app.Map("/Form", app =>
{
    app.Run(async context =>
    {
        // code ở đây
        await context.Response.WriteAsync("/Form");
    });
});


app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = StatusCodes.Status404NotFound;
    await context.Response.WriteAsync("Page not found!");
});


app.Run();
