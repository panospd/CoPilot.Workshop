using CoPilot.Workshop.Infra.Data;
using CoPilot.Workshop.App;
using CoPilot.Workshop.App.Products;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using CoPilot.Workshop.Framework; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDataServices(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string is required"));
builder.Services.RegisterAppServices(); // Call the extension method here

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        // Explicitly define the types for statusCode and response
        var (statusCode, response) = exception switch
        {
            ValidationException validationException => (
                StatusCodes.Status400BadRequest,
                new
                {
                    Title = "Validation Errors",
                    validationException.Errors
                }
            ),
            _ => (
                StatusCodes.Status500InternalServerError,
                (object)new
                {
                    Title = "An unexpected error occurred.",
                    Detail = exception?.Message
                }
            )
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
