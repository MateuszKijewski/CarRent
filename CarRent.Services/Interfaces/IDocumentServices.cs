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
        int AddOrder(int carId, int workerId, int coordinatorId, int regionId, int clientId, AddOrderDto addOrderDto);
        GetOrderDto GetOrder(int id);
        int DeleteOrder(int id);
        IEnumerable<GetOrderDto> GetAllOrders();
        IEnumerable<GetOrderDto> FilterOrders(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange);

        int AddRepairReport(int orderId, AddRepairReportDto addRepairReport);
        GetRepairReportDto GetRepairReport(int id);
        int DeleteRepairReport(int id);
        IEnumerable<GetRepairReportDto> GetAllRepairReports();
        IEnumerable<GetRepairReportDto> FilterRepairReports(string description, decimal[] costRange, int[] timeRange);

        int AddReturnReport(int orderId, AddReturnReportDto addReturnReport);
        GetReturnReportDto GetReturnReport(int id);
        int DeleteReturnReport(int id);
        IEnumerable<GetReturnReportDto> GetAllReturnReports();
        IEnumerable<GetReturnReportDto> FilterReturnReports(int[] drivenDistanceRange, DateTime[] dateRange, Dictionary<string, bool> damaged);
    }
}
