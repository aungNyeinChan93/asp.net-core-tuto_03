var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.StatusCode = 201;
    return $"Hello world";
});

app.Run();
