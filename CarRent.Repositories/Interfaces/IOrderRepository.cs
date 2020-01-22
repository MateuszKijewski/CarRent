using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Repositories
{
    public interface IOrderRepository
    {
        Order Get(int id);
        int Add(Order order);
        int Delete(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> Filter(string deliveryPlace, int[] rentalTimeRange, Decimal[] costRange, DateTime[] dateRange, Dictionary<string, bool> finished);
        Order Update(int id, Order order);
    }
}
