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
                CarDescription = order.Car.Description(),

                CarId = order.CarId,
                WorkerId = order.WorkerId,
                RegionId = order.RegionId,
                ClientId = order.ClientId

            };
        }
    }
}
