
using Infrastructure;
using Application;
using Web.API.Extensions;

using Microsoft.OpenApi.Models;


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
    c.SwaggerDoc("v1", new() { Title = "Moodle Aplicativo API", Version = "v1" });

    //Boton de autorizacion
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization ",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {

        {
            new OpenApiSecurityScheme
            {
                Reference =  new OpenApiReference
                {
                    Type =  ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new  string [] {}
        }
    });
        
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



