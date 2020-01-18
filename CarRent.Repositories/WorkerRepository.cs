using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.DataAccess;
using CarRent.Models.Entities;

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

            if (salaryRange != null)
            {
                var filteredSalary = _db.Workers.Where(w => w.Salary >= salaryRange[0]
                                                        && w.Salary <= salaryRange[1]);
                foreach (var item in filteredSalary) { duplicatesResult.Add(item); }
            }

            foreach (KeyValuePair<string, string> pair in stringQueries)
            {
                switch (pair.Key)
                {
                    case "FirstName":
                        var filteredFirstNames = _db.Workers.Where(w => w.FirstName.Contains($"/{pair}/"));
                        foreach (var item in filteredFirstNames) { duplicatesResult.Add(item); }
                        break;

                    case "LastName":
                        var filteredLastNames = _db.Workers.Where(w => w.LastName.Contains($"/{pair}/"));
                        foreach (var item in filteredLastNames) { duplicatesResult.Add(item); }
                        break;

                    case "Phone":
                        var filteredPhoneNumbers = _db.Workers.Where(w => w.PhoneNumber.Contains($"/{pair}/"));
                        foreach (var item in filteredPhoneNumbers) { duplicatesResult.Add(item); }
                        break;

                    case "Email":
                        var filteredEmails = _db.Workers.Where(w => w.Email.Contains($"/{pair}/"));
                        foreach (var item in filteredEmails) { duplicatesResult.Add(item); }
                        break;
                }
            }

            List<Worker> finalResult = duplicatesResult.Distinct().ToList();
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
    }
}
