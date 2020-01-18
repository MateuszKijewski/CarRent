using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Repositories
{
    public interface IWorkerRepository
    {
        Worker Get(int id);
        IEnumerable<Worker> GetAll();
        int Add(Worker car);
        int Delete(int id);
        IEnumerable<Worker> Filter(Dictionary<string, string> stringQueries, int[] salaryRange);
    }
}
