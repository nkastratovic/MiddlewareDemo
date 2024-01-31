var builder = WebApplication.CreateBuilder(args);

//Register MyMiddlewareClass as a service
builder.Services.AddSingleton<MyMiddlewareClass>();

var app = builder.Build();

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Middleware 1 Request\n");
    await next(context);
    await context.Response.WriteAsync("Middleware 1 Response\n");
});

//Run MyMiddlewareClass
app.UseMiddleware<MyMiddlewareClass>();
app.UseMyCustomMiddleware();

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Middleware 2 Request\n");
    await next(context);
    await context.Response.WriteAsync("Middleware 2 Response\n");
});

//UseWhen Method
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app => {
        app.Use(async (HttpContext context, RequestDelegate next) =>
        {
            await context.Response.WriteAsync("Query contains username\n");
            await next(context);
        });
    });

//Middleware 3
//Run is predefined method to create middleware, in Run method define lambda expression to execute when request is received
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 3\n");
});

app.Run();
