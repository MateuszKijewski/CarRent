using System;
using System.Collections.Generic;
using System.Text;
using CarRent.Models.Dtos;
using CarRent.Models.Entities;

namespace CarRent.Models.Converters
{
    public class OrderConverter : IOrderConverter
    {
        public Order AddOrderDtoToOrder(AddOrderDto addOrderDto)
        {
            return new Order
            {
                OrderDate = addOrderDto.OrderDate,
                RentalTime = addOrderDto.RentalTime,
                DeliveryPlace = addOrderDto.DeliveryPlace
            };
        }

        public GetOrderDto OrderToGetOrderDto(Order order)
        {
            return new GetOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                RentalTime = order.RentalTime,
                DeliveryPlace = order.DeliveryPlace,
                Cost = order.Cost,
                IsDeleted = order.IsDeleted,
                Finished = order.Finished,

                CarId = order.CarId,
                WorkerId = order.WorkerId,
                ClientId = order.ClientId

            };
        }

        public Order UpdateOrderDtoToOrder(UpdateOrderDto updateOrderDto)
        {
            return new Order
            {
                OrderDate = updateOrderDto.OrderDate,
                RentalTime = updateOrderDto.RentalTime,
                DeliveryPlace = updateOrderDto.DeliveryPlace
            };
        }
    }
}
