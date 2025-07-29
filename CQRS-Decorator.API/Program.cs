using CQRS_Decorator.API; 
using CQRS_Decorator.API.Extensions;
using CQRS_Decorator.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string corsPolicy = "CorsPolicy";

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsInApplication(corsPolicy);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.InitializeServices(builder.Configuration);  
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
