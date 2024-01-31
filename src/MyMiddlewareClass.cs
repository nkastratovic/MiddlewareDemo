
public class MyMiddlewareClass : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("MyMiddlewareClass Request\n");
        await next(context);
        await context.Response.WriteAsync("MyMiddlewareClass Response\n");
    }
}

public static class CustomMiddlewareExtension
{
    //Extension method - method injected into an existing object dynamically.
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<MyMiddlewareClass>();
    }
}