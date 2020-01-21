using CarRent.Models.Dtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters
{
    public interface IOrderConverter
    {
        GetOrderDto OrderToGetOrderDto(Order order);
        Order AddOrderDtoToOrder(AddOrderDto addOrderDto);
        Order UpdateOrderDtoToOrder(UpdateOrderDto updateOrderDto);
    }
}
