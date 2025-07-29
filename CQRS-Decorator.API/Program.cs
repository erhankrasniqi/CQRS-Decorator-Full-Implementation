using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Application.Commands.CreateUser;
using CQRS_Decorator.Application.Dispatchers;
using CQRS_Decorator.Application.Queries;
using CQRS_Decorator.Decorators;
using CQRS_Decorator.Domain.Entities;
using CQRS_Decorator.Domain.Interfaces;
using CQRS_Decorator.Infrastructure.Data;
using CQRS_Decorator.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();

// Register handler
builder.Services.AddScoped<ICommandHandler<CreateUserCommand, Guid>, CreateUserCommandHandler>();

// Decorators
builder.Services.Decorate<ICommandHandler<CreateUserCommand, Guid>, ValidationDecorator<CreateUserCommand, Guid>>();
builder.Services.Decorate<ICommandHandler<CreateUserCommand, Guid>, LoggingDecorator<CreateUserCommand, Guid>>();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();
builder.Services.AddScoped<IQueryHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllUserQuery, IEnumerable<User>>, GetAllUserQueryHandler>();


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
