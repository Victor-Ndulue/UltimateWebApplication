using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using UltimateWebApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Adding a path to the Nlog configuration.
LogManager.LoadConfiguration(string
    .Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//Adding user built extensions
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();

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

app.MapControllers();

app.Run();
