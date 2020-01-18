using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;

namespace CarRent.Services
{
    public class DocumentServices : IDocumentService
    {
        private readonly IOrderConverter _orderConverter;
        private readonly IOrderRepository _orderRepository;

        public DocumentServices(IOrderConverter orderConverter, IOrderRepository orderRepository)
        {
            _orderConverter = orderConverter;
            _orderRepository = orderRepository;
        }

        public int AddOrder(int carId, int workerId, int coordinatorId, int regionId, AddOrderDto addOrderDto)
        {
            var order = _orderConverter.AddOrderDtoToOrder(addOrderDto);
            order.CarId = carId;
            order.WorkerId = workerId;
            order.CoordinatorId = coordinatorId;
            order.RegionId = regionId;

            return _orderRepository.Add(order);
        }

        public IEnumerable<GetOrderDto> FilterOrders(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange)
        {
            return _orderRepository.Filter(deliveryPlace, rentalTimeRange, costRange, dateRange)
                .Select(o => _orderConverter.OrderToGetOrderDto(o));
        }

        public IEnumerable<GetOrderDto> GetAllOrders()
        {
            return _orderRepository.GetAll()
                .Select(o => _orderConverter.OrderToGetOrderDto(o));
        }

        public GetOrderDto GetOrder(int id)
        {
            return _orderConverter.OrderToGetOrderDto(_orderRepository.Get(id));
        }
    }
}
