using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using UltimateWebApplication.Extensions;


//Adding a path to the Nlog configuration.
LogManager.LoadConfiguration(string
    .Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding user built extensions
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));

//Registering the repository context
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
//Adding mandatory methods
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"Logic before executing the next delegate");
//    await next.Invoke();
//    Console.WriteLine("After the next");
//});
//app.Map("/usingmapbranch", builder =>
//{
//    builder.Use(async (context, next) =>
//    {
//        Console.WriteLine("Map branch before next");
//        await next.Invoke();
//        Console.WriteLine("Map branch after next");
//    });
//    builder.Run(async context =>
//    {
//        Console.WriteLine("Map branch to the client in run method");
//        await context.Response.WriteAsync("Hello from the map branch");
//    });
//});

app.MapControllers();

app.Run();
