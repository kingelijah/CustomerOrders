using AutoMapper;
using CustomerOrders.API.DTOs;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
using CustomerOrders.Application.Commands.Orders.CreateOrders;
using CustomerOrders.Application.Commands.Products.CreateProducts;
using CustomerOrders.Application.Commands.Products.UpdateProducts;
using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using System.Data;

namespace CustomerOrders.API.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateProductDTO, CreateProductCommand>();

            CreateMap<CreateProductCommand, CreateProductDTO>();

            CreateMap<UpdateProductDTO, UpdateProductCommand>();

            CreateMap<UpdateProductCommand, UpdateProductDTO>();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDTO>();

            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderDTO>();

            CreateMap<ItemDTO, Item>();

            CreateMap<Item, ItemDTO>();

            CreateMap<CreateOrderDTO, CreateOrderCommand>();

            CreateMap<CreateOrderCommand, CreateOrderDTO>();

            CreateMap<CreateCustomerDTO, CreateCustomerCommand>();

            CreateMap< CreateCustomerCommand, CreateCustomerDTO>();

            CreateMap<UpdateCustomerDTO, UpdateCustomerCommand>();

            CreateMap<UpdateCustomerCommand, UpdateCustomerDTO>();

            CreateMap<CustomerDTO, Customer>();

            CreateMap<Customer, CustomerDTO>();

            CreateMap<Price, decimal>().ConvertUsing(r => r.Value);
            CreateMap<decimal, Price>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));
        }
    }
}
