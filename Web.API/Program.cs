
using Infrastructure;
using Application;
using Web.API.Extensions;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);





builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Aplicativo API", Version = "v1" });

    
        
});



//JWT

builder.Services.AddAuthorization();



//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();


//Se puede personalidad el error para saber si viene del cliente o del servidor.
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {
            var exception = error.Error;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = exception.Message  // Devuelve el mensaje de la excepción
            };

            
            if (exception is ArgumentException)
            {
                context.Response.StatusCode = 400; 
            }
            else if (exception is KeyNotFoundException)
            {
                context.Response.StatusCode = 404; 
            }
            else
            {
                context.Response.StatusCode = 500; 
            }

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    });
});

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();



