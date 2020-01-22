using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CarRent.DataAccess;
using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {

        private readonly CarRentDbContext _db;

        public WorkerRepository(CarRentDbContext db)
        {
            _db = db;
        }


        public int Add(Worker worker)
        {
            _db.Workers.Add(worker);            
            _db.SaveChanges();

            return worker.Id;
        }

        public int Delete(int id)
        {
            var worker = _db.Workers.First(w => w.Id == id);
            worker.IsDeleted = true;
            _db.SaveChanges();

            return worker.Id;
        }

        public IEnumerable<Worker> Filter(Dictionary<string, string> stringQueries, int[] salaryRange)
        {
            List<Worker> duplicatesResult = new List<Worker>();
            int queryCount = 0;

            if (salaryRange != null)
            {
                queryCount++;
                var filteredSalary = _db.Workers.Where(w => w.Salary >= salaryRange[0]
                                                        && w.Salary <= salaryRange[1]);
                foreach (var item in filteredSalary) { duplicatesResult.Add(item); }
            }

            foreach (KeyValuePair<string, string> pair in stringQueries)
            {
                switch (pair.Key)
                {
                    case "FirstName":
                        var filteredFirstNames = _db.Workers.Where(w => EF.Functions.Like(w.FirstName, $"%{pair.Value}%"));
                        foreach (var item in filteredFirstNames) { duplicatesResult.Add(item); }
                        break;

                    case "LastName":
                        var filteredLastNames = _db.Workers.Where(w => EF.Functions.Like(w.LastName, $"%{pair.Value}%"));
                        foreach (var item in filteredLastNames) { duplicatesResult.Add(item); }
                        break;

                    case "PhoneNumber":
                        var filteredPhoneNumbers = _db.Workers.Where(w => EF.Functions.Like(w.PhoneNumber, $"%{pair.Value}%"));
                        foreach (var item in filteredPhoneNumbers) { duplicatesResult.Add(item); }
                        break;

                    case "Email":
                        var filteredEmails = _db.Workers.Where(w => EF.Functions.Like(w.Email, $"%{pair.Value}%"));
                        foreach (var item in filteredEmails) { duplicatesResult.Add(item); }
                        break;
                }
            }
            
            if (stringQueries == null) { stringQueries = new Dictionary<string, string>(); queryCount += stringQueries.Count; }
            else { queryCount += stringQueries.Count; }

            List<Worker> finalResult = new List<Worker>();
            var grouped = duplicatesResult.GroupBy(i => i);
            foreach (var g in grouped)
            {
                if (g.Count() == queryCount)
                {
                    finalResult.Add(g.Key);
                }
            }
            return finalResult;
        }

        public Worker Get(int id)
        {
            return _db.Workers.First(w => w.Id == id);
        }

        public IEnumerable<Worker> GetAll()
        {
            return _db.Workers;
        }

        public Worker Update(int id, Worker worker)
        {
            var currentRecord = _db.Workers.First(w => w.Id == id);
            foreach (PropertyInfo property in worker.GetType().GetProperties())
            {
                var value = worker.GetType().GetProperty(property.Name).GetValue(worker, null);
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
