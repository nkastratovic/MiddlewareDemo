var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Run is predefined method to create middleware, in Run method define lambda expression to execute when request is received
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 1\n");
});

app.Run();
