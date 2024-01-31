
public class MyMiddlewareClass : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("MyMiddlewareClass Request\n");
        await next(context);
        await context.Response.WriteAsync("MyMiddlewareClass Response\n");
    }
}