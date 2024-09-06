using CustomerOrders.API.Behaviors;
using CustomerOrders.API.Mapping;
using CustomerOrders.API.Middleware;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Commands.Products.CreateProducts;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Infrastructure;
using CustomerOrders.Infrastructure.Data.Configurations;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
               // .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerOrdersConnection")));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProductCommand>());
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        builder.Services.AddValidatorsFromAssembly(Assembly.Load("CustomerOrders.Application"));
       // builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddAutoMapper(typeof(UserProfile)); // Registers all profiles in the assembly

        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}