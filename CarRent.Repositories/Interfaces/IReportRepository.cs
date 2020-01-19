using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Repositories.Interfaces
{
    public interface IReportRepository
    {
        int AddReturnReport(ReturnReport returnReport);
        ReturnReport GetReturnReport(int id);
        int DeleteReturnReport(int id);
        IEnumerable<ReturnReport> GetAllReturnReports();
        IEnumerable<ReturnReport> FilterReturnReports(int[] drivenDistanceRange, DateTime[] dateRange, Dictionary<string, bool> damaged);


        int AddRepairReport(RepairReport repairReport);
        RepairReport GetRepairReport(int id);
        int DeleteRepairReport(int id);
        IEnumerable<RepairReport> GetAllRepairReports();
        IEnumerable<RepairReport> FilterRepairReports(string description, Decimal[] costRange, int[] timeRange);
    }
}
