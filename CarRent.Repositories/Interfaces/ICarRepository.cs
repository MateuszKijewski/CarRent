using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Repositories
{
    public interface ICarRepository
    {
        Car Get(int id);
        IEnumerable<Car> GetAll();
        int Add(Car car);
        int Delete(int id);
        IEnumerable<Car> Filter(Dictionary<string, string> stringQueries, Dictionary<string, int[]> intQueries);
        Car Update(int id, Car car);
    }
}
