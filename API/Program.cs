
using System.Text;
using API;
using API.Data;
using API.Interfaces;
using API.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
 
builder.Services.AddCors();

builder.Services.AddScoped<ITokenService, TokenService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
 