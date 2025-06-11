
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlogsManagement.Middleware; // Namespace where your middleware lives
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// For model validation error responses
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Custom middleware for logging
app.UseMiddleware<LoggingMiddleware>();

// Custom middleware for authentication (example use case)
app.UseMiddleware<AuthenticationMiddleware>();

app.UseRouting();

// Use authorization if needed
// app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
