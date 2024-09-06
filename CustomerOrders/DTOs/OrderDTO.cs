﻿using CustomerOrders.Domain.Domain;
using CustomerOrders.Domain.Domain.ValueObjects;
using FluentValidation;

namespace CustomerOrders.API.DTOs
{
    public class OrderDTO
    {
        public List<ItemDTO> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }

    }

}
