using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface IDocumentService
    {
        int AddOrder(int carId, int workerId, int coordinatorId, int regionId, AddOrderDto addOrderDto);
        GetOrderDto GetOrder(int id);
        IEnumerable<GetOrderDto> GetAllOrders();
        IEnumerable<GetOrderDto> FilterOrders(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange);
    }
}
