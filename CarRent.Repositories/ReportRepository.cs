using CarRent.DataAccess;
using CarRent.Models.Entities;
using CarRent.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarRent.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly CarRentDbContext _db;

        public ReportRepository(CarRentDbContext db)
        {
            _db = db;
        }


        public int AddRepairReport(RepairReport repairReport)
        {
            _db.RepairReports.Add(repairReport);
            _db.SaveChanges();

            return repairReport.Id;
        }

        public int AddReturnReport(ReturnReport returnReport)
        {
            _db.ReturnReports.Add(returnReport);
            _db.SaveChanges();

            return returnReport.Id;
        }

        public int DeleteRepairReport(int id)
        {
            var repairReport = _db.RepairReports.First(rr => rr.Id == id);
            repairReport.IsDeleted = true;
            _db.SaveChanges();

            return repairReport.Id;
        }

        public int DeleteReturnReport(int id)
        {
            var returnReport = _db.ReturnReports.First(rr => rr.Id == id);
            returnReport.IsDeleted = true;
            _db.SaveChanges();

            return returnReport.Id;
        }

        public IEnumerable<RepairReport> FilterRepairReports(string description, decimal[] costRange, int[] timeRange)
        {
            List<RepairReport> duplicatesResult = new List<RepairReport>();
            int queryCount = 0;

            if (description != null)
            {
                queryCount++;
                var filteredDescriptions = _db.RepairReports.Where(rr => EF.Functions.Like(rr.Description, $"%{description}%"));
                foreach (var item in filteredDescriptions) { duplicatesResult.Add(item); }
            }
            if (costRange != null)
            {
                queryCount++;
                var filteredCosts = _db.RepairReports.Where(rr => rr.Cost >= costRange[0]
                                                            && rr.Cost <= costRange[1]);
                foreach(var item in filteredCosts) { duplicatesResult.Add(item); }
            }
            if (timeRange != null)
            {
                queryCount++;
                var filteredTimes = _db.RepairReports.Where(rr => rr.Time <= timeRange[0]
                                                            && rr.Time >= timeRange[1]);
                foreach(var item in filteredTimes) { duplicatesResult.Add(item); }
            }
            
            List<RepairReport> finalResult = new List<RepairReport>();
            var grouped = duplicatesResult.GroupBy(i => i);
            foreach(var g in grouped)
            {
                if (g.Count() == queryCount)
                {
                    finalResult.Add(g.Key);
                }
            }

            return finalResult;
        }

        public IEnumerable<ReturnReport> FilterReturnReports(int[] drivenDistanceRange, DateTime[] dateRange, Dictionary<string, bool> damaged)
        {
            List<ReturnReport> duplicatesResult = new List<ReturnReport>();
            int queryCount = 0;

            if (drivenDistanceRange != null)
            {
                queryCount++;
                var filteredDistances = _db.ReturnReports.Where(rr => rr.DrivenDistance >= drivenDistanceRange[0]
                                                                && rr.DrivenDistance <= drivenDistanceRange[1]);
                foreach(var item in filteredDistances) { duplicatesResult.Add(item); }
            }
            if (dateRange != null)
                queryCount++;
            {
                var filteredDates = _db.ReturnReports.Where(rr => rr.ReturnDate >= dateRange[0]
                                                            && rr.ReturnDate <= dateRange[1]);
                foreach(var item in filteredDates) { duplicatesResult.Add(item); }
            }
            if (damaged != null)
            {
                foreach (KeyValuePair<string, bool> pair in damaged)
                {
                    switch (pair.Key)
                    {
                        case "Damaged":
                            var filterDamaged = _db.ReturnReports.Where(rr => rr.IsDamaged == true);
                            foreach (var item in filterDamaged) { duplicatesResult.Add(item); }
                            break;

                        case "notDamaged":
                            var filterNotDamaged = _db.ReturnReports.Where(rr => rr.IsDamaged == false);
                            foreach (var item in filterNotDamaged) { duplicatesResult.Add(item); }
                            break;
                    }
                }
            }
            if (damaged == null ) { damaged = new Dictionary<string, bool>(); queryCount += damaged.Count; }

            List<ReturnReport> finalResult = new List<ReturnReport>();
            var grouped = duplicatesResult.GroupBy(i => i);
            foreach(var g in grouped)
            {
                if (g.Count() == queryCount)
                {
                    finalResult.Add(g.Key);
                }
            }
            return finalResult.Where(rr => rr.IsDeleted == false);
        }

        public IEnumerable<RepairReport> GetAllRepairReports()
        {
            return _db.RepairReports.Where(rr => rr.IsDeleted == false);
        }

        public IEnumerable<ReturnReport> GetAllReturnReports()
        {
            return _db.ReturnReports.Where(rr => rr.IsDeleted == false);
        }

        public RepairReport GetRepairReport(int id)
        {
            try
            {
                return _db.RepairReports.First(rr => rr.Id == id);
            }
            catch(InvalidOperationException e)
            {
                return null;
            }
        }

        public ReturnReport GetReturnReport(int id)
        {
            return _db.ReturnReports.First(rr => rr.Id == id);
        }

        public RepairReport UpdateRepairReport(int id, RepairReport repairReport)
        {
            var currentRecord = _db.RepairReports.First(rr => rr.Id == id);
            foreach (PropertyInfo property in repairReport.GetType().GetProperties())
            {
                var value = repairReport.GetType().GetProperty(property.Name).GetValue(repairReport, null);
                if (value != null && property.Name.ToLower() != "id")
                {
                    currentRecord.GetType().GetProperty(property.Name).SetValue(currentRecord, value);
                }
            }
            _db.SaveChanges();

            return currentRecord;
        }

        public ReturnReport UpdateReturnReport(int id, ReturnReport returnReport)
        {
            var currentRecord = _db.ReturnReports.First(rr => rr.Id == id);
            foreach (PropertyInfo property in returnReport.GetType().GetProperties())
            {
                var value = returnReport.GetType().GetProperty(property.Name).GetValue(returnReport, null);
                if (value != null && property.Name.ToLower() != "id")
                {
                    currentRecord.GetType().GetProperty(property.Name).SetValue(currentRecord, value);
                }
            }
            _db.SaveChanges();

            return currentRecord;
        }
    }
}
