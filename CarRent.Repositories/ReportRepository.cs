﻿using CarRent.DataAccess;
using CarRent.Models.Entities;
using CarRent.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (description != null)
            {
                var filteredDescriptions = _db.RepairReports.Where(rr => rr.Description.Contains($"/{description}/"));
                foreach(var item in filteredDescriptions) { duplicatesResult.Add(item); }
            }
            if (costRange != null)
            {
                var filteredCosts = _db.RepairReports.Where(rr => rr.Cost >= costRange[0]
                                                            && rr.Cost <= costRange[1]);
                foreach(var item in filteredCosts) { duplicatesResult.Add(item); }
            }
            if (timeRange != null)
            {
                var filteredTimes = _db.RepairReports.Where(rr => rr.Time <= timeRange[0]
                                                            && rr.Time >= timeRange[1]);
                foreach(var item in filteredTimes) { duplicatesResult.Add(item); }
            }

            List<RepairReport> finalResult = duplicatesResult.Distinct().ToList();
            return finalResult;
        }

        public IEnumerable<ReturnReport> FilterReturnReports(int[] drivenDistanceRange, DateTime[] dateRange, Dictionary<string, bool> damaged)
        {
            List<ReturnReport> duplicatesResult = new List<ReturnReport>();
            if (drivenDistanceRange != null)
            {
                var filteredDistances = _db.ReturnReports.Where(rr => rr.DrivenDistance >= drivenDistanceRange[0]
                                                                && rr.DrivenDistance <= drivenDistanceRange[1]);
                foreach(var item in filteredDistances) { duplicatesResult.Add(item); }
            }
            if (dateRange!= null)
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
            
            List<ReturnReport> finalResult = duplicatesResult.Distinct().ToList();
            return finalResult;
        }

        public IEnumerable<RepairReport> GetAllRepairReports()
        {
            return _db.RepairReports;
        }

        public IEnumerable<ReturnReport> GetAllReturnReports()
        {
            return _db.ReturnReports;
        }

        public RepairReport GetRepairReport(int id)
        {
            return _db.RepairReports.First(rr => rr.Id == id);
        }

        public ReturnReport GetReturnReport(int id)
        {
            return _db.ReturnReports.First(rr => rr.Id == id);
        }
    }
}