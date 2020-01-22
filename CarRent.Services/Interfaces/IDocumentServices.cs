using CarRent.Models.Dtos;
using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface IDocumentService
    {
        string AddOrder(int carId, int workerId, int clientId, AddOrderDto addOrderDto);
        GetOrderDto GetOrder(int id);
        string DeleteOrder(int id);
        IEnumerable<GetOrderDto> GetAllOrders();
        IEnumerable<GetOrderDto> FilterOrders(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange, Dictionary<string, bool> finished);
        GetOrderDto UpdateOrder(int id, UpdateOrderDto updateOrderDto);

        string AddRepairReport(int orderId, AddRepairReportDto addRepairReport);
        GetRepairReportDto GetRepairReport(int id);
        string DeleteRepairReport(int id);
        IEnumerable<GetRepairReportDto> GetAllRepairReports();
        IEnumerable<GetRepairReportDto> FilterRepairReports(string description, decimal[] costRange, int[] timeRange);
        GetRepairReportDto UpdateRepairReport(int id, UpdateRepairReportDto updateRepairReportDto);

        string AddReturnReport(int orderId, AddReturnReportDto addReturnReport);
        GetReturnReportDto GetReturnReport(int id);
        string DeleteReturnReport(int id);
        IEnumerable<GetReturnReportDto> GetAllReturnReports();
        IEnumerable<GetReturnReportDto> FilterReturnReports(int[] drivenDistanceRange, DateTime[] dateRange, Dictionary<string, bool> damaged);
        GetReturnReportDto UpdateReturnReport(int id, UpdateReturnReportDto updateReturnReportDto);
    }
}
