using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.Models.Converters;
using CarRent.Models.Converters.Interfaces;
using CarRent.Models.Dtos;
using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using CarRent.Repositories;
using CarRent.Repositories.Interfaces;

namespace CarRent.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IOrderConverter _orderConverter;
        private readonly IOrderRepository _orderRepository;
        private readonly IReportConverter _reportConverter;
        private readonly IReportRepository _reportRepository;
        private readonly ICarRepository _carRepository;
        private readonly IWorkerRepository _workerRepository;

        public DocumentService(IOrderConverter orderConverter, IOrderRepository orderRepository,
                                IReportConverter reportConverter, IReportRepository reportRepository,
                                ICarRepository carRepository, IWorkerRepository workerRepository)
        {
            _orderConverter = orderConverter;
            _orderRepository = orderRepository;
            _reportConverter = reportConverter;
            _reportRepository = reportRepository;
            _carRepository = carRepository;
            _workerRepository = workerRepository;
        }
        
        /* Add to DB actions */
        public string AddOrder(int carId, int workerId, int clientId, AddOrderDto addOrderDto)
        {
            var order = _orderConverter.AddOrderDtoToOrder(addOrderDto);
            order.CarId = carId;
            order.WorkerId = workerId;
            var car = _carRepository.Get(carId);
            car.WorkerId = workerId;
            _workerRepository.Get(workerId).Car = car;
            order.ClientId = clientId;


            _orderRepository.Add(order);
            return $"Order with id {order.Id} was succesfuly deleted";
        }

        public string AddRepairReport(int orderId, AddRepairReportDto addRepairReport)
        {
            var repairReport = _reportConverter.AddRepairReportDtoToRepairReport(addRepairReport);
            repairReport.OrderId = orderId;

            _reportRepository.AddRepairReport(repairReport);
            return $"Repair report with id {repairReport.Id} was succesfuly deleted";
        }
        
        public string AddReturnReport(int orderId, AddReturnReportDto addReturnReport)
        {
            var returnReport = _reportConverter.AddReturnReportDtoToReturnReport(addReturnReport);
            returnReport.OrderId = orderId;

            _reportRepository.AddReturnReport(returnReport);
            return $"Return report with id {returnReport.Id} was succesfuly deleted";
        }

        /* Delete from DB actions */
        public string DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
            return $"Order with id {id} was succesfuly deleted";
        }

        public string DeleteRepairReport(int id)
        {
            _reportRepository.DeleteRepairReport(id);
            return $"Repair report with id {id} was succesfuly deleted";
        }

        public string DeleteReturnReport(int id)
        {
            _reportRepository.DeleteReturnReport(id);
            return $"Return report with id {id} was succesfuly deleted";
        }

        /* Filter from Db actions */
        public IEnumerable<GetOrderDto> FilterOrders(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange, Dictionary<string, bool> finished)
        {
            return _orderRepository.Filter(deliveryPlace, rentalTimeRange, costRange, dateRange, finished)
                .Select(o => _orderConverter.OrderToGetOrderDto(o));
        }
        
        public IEnumerable<GetRepairReportDto> FilterRepairReports(string description, decimal[] costRange, int[] timeRange)
        {
            return _reportRepository.FilterRepairReports(description, costRange, timeRange)
                .Select(rr => _reportConverter.RepairReportToGetRepairReportDto(rr));
        }

        public IEnumerable<GetReturnReportDto> FilterReturnReports(int[] drivenDistanceRange, DateTime[] dateRange, 
                                                                    Dictionary<string, bool> damaged)
        {
            return _reportRepository.FilterReturnReports(drivenDistanceRange, dateRange, damaged)
                .Select(rr => _reportConverter.ReturnReportToGetReturnReportDto(rr));
        }

        /* GetAll from Db actions */
        public IEnumerable<GetOrderDto> GetAllOrders()
        {
            return _orderRepository.GetAll()
                .Select(o => _orderConverter.OrderToGetOrderDto(o));
        }

        public IEnumerable<GetRepairReportDto> GetAllRepairReports()
        {
            return _reportRepository.GetAllRepairReports()
                .Select(rr => _reportConverter.RepairReportToGetRepairReportDto(rr));
        }

        public IEnumerable<GetReturnReportDto> GetAllReturnReports()
        {
            return _reportRepository.GetAllReturnReports()
                .Select(rr => _reportConverter.ReturnReportToGetReturnReportDto(rr));
        }

        /* Get from Db actions */
        public GetOrderDto GetOrder(int id)
        {
            return _orderConverter.OrderToGetOrderDto(_orderRepository.Get(id));
        }

        public GetRepairReportDto GetRepairReport(int id)
        {
            return _reportConverter.RepairReportToGetRepairReportDto(_reportRepository.GetRepairReport(id));
        }

        public GetReturnReportDto GetReturnReport(int id)
        {
            return _reportConverter.ReturnReportToGetReturnReportDto(_reportRepository.GetReturnReport(id));
        }

        /* Update in Db actions */
        public GetOrderDto UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var updateOrder = _orderConverter.UpdateOrderDtoToOrder(updateOrderDto);
            return _orderConverter.OrderToGetOrderDto(_orderRepository.Update(id, updateOrder)); 
        }

        public GetRepairReportDto UpdateRepairReport(int id, UpdateRepairReportDto updateRepairReportDto)
        {
            var updateRepairReport = _reportConverter.UpdateRepairReportDtoToRepairReport(updateRepairReportDto);
            return _reportConverter.RepairReportToGetRepairReportDto(_reportRepository.UpdateRepairReport(id, updateRepairReport));
        }

        public GetReturnReportDto UpdateReturnReport(int id, UpdateReturnReportDto updateReturnReportDto)
        {
            var updateReturnReport = _reportConverter.UpdateReturnReportDtoToReturnReport(updateReturnReportDto);
            return _reportConverter.ReturnReportToGetReturnReportDto(_reportRepository.UpdateReturnReport(id, updateReturnReport));
        }
    }
}
