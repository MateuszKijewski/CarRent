using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Repositories
{
    public interface IClientRepository
    {
        Client Get(int id);
        IEnumerable<Client> GetAll();
        int Add(Client client);
        int Delete(int id);
        IEnumerable<Client> Filter(Dictionary<string, string> stringQueries, Dictionary<string, bool> isCompany);
    }
}
