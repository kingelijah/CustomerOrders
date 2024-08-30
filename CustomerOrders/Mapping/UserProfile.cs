using AutoMapper;
using CustomerOrders.API.DTOs;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Domain.Domain;

namespace CustomerOrders.API.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateProductDTO, CreateProductCommandHandlers.Command>();

            CreateMap<CreateProductCommandHandlers.Command, CreateProductDTO>();

            CreateMap<UpdateProductDTO, UpdateProductCommandHandler.Command>();

            CreateMap<UpdateProductCommandHandler.Command, UpdateProductDTO>();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDTO>();

            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderDTO>();

            CreateMap<ItemDTO, Item>();

            CreateMap<Item, ItemDTO>();

            CreateMap<CreateOrderDTO, CreateOrderCommandHandlers.Command>();

            CreateMap<CreateOrderCommandHandlers.Command, CreateOrderDTO>();

            CreateMap<CreateCustomerDTO, CreateCustomerCommandHandlers.Command>();

            CreateMap<CreateCustomerCommandHandlers.Command, CreateCustomerDTO>();

            CreateMap<UpdateCustomerDTO, UpdateCustomerCommandHandler.Command>();

            CreateMap<UpdateCustomerCommandHandler.Command, UpdateCustomerDTO>();

            CreateMap<CustomerDTO, Customer>();

            CreateMap<Customer, CustomerDTO>();
        }
    }
}
