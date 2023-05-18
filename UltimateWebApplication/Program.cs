using Microsoft.AspNetCore.HttpOverrides;
using UltimateWebApplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding user built extensions
builder.Services.ConfigureCors();
builder.Services.ConfigureIIsIntegration();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
