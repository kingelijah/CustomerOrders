using CustomerOrders.API.DTOs;
using CustomerOrders.API.Mapping;
using CustomerOrders.API.Middleware;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Domain.Interfaces;
using CustomerOrders.Infrastructure;
using CustomerOrders.Infrastructure.Data.Configurations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerOrdersConnection")));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProductCommandHandlers.Command>());
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