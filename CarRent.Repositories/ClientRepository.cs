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
    public class ClientRepository : IClientRepository
    {
        private readonly CarRentDbContext _db;

        public ClientRepository(CarRentDbContext db)
        {
            _db = db;
        }

        public int Add(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();

            return client.Id;
        }

        public int Delete(int id)
        {
            var client = _db.Clients.First(c => c.Id == id);
            client.IsDeleted = true;
            _db.SaveChanges();

            return client.Id;
        }

        public IEnumerable<Client> Filter(Dictionary<string, string> stringQueries, Dictionary<string, bool> company)
        {
            List<Client> duplicatesResult = new List<Client>();

            if (company != null)
            {
                foreach(KeyValuePair<string, bool> pair in company)
                {
                    switch (pair.Key)
                    {
                        case "Company":
                            var filteredCompanies = _db.Clients.Where(c => c.IsCompany == true);
                            foreach (var item in filteredCompanies) { duplicatesResult.Add(item); }
                            break;
                        case "notCompany":
                            var filteredNotCompanies = _db.Clients.Where(c => c.IsCompany == false);
                            foreach (var item in filteredNotCompanies) { duplicatesResult.Add(item); }
                            break;
                    }
                }
                
            }

            foreach (KeyValuePair<string, string> pair in stringQueries)
            {
                switch (pair.Key)
                {
                    case "FirstName":
                        var filteredFirstNames = _db.Clients.Where(c => EF.Functions.Like(c.FirstName, $"%{pair.Value}%"));
                        foreach (var item in filteredFirstNames) { duplicatesResult.Add(item); }
                        break;

                    case "LastName":
                        var filteredLastNames = _db.Clients.Where(c => EF.Functions.Like(c.LastName,$"%{pair.Value}%"));
                        foreach (var item in filteredLastNames) { duplicatesResult.Add(item); }
                        break;

                    case "PhoneNumber":
                        var filteredPhoneNumbers = _db.Clients.Where(c => EF.Functions.Like(c.PhoneNumber, $"%{pair.Value}%"));
                        foreach (var item in filteredPhoneNumbers) { duplicatesResult.Add(item); }
                        break;

                    case "Email":
                        var filteredEmails = _db.Clients.Where(c => EF.Functions.Like(c.Email, $"%{pair.Value}%"));
                        foreach (var item in filteredEmails) { duplicatesResult.Add(item); }
                        break;

                    case "DriversLicenseNumber":
                        var filteredLicenses = _db.Clients.Where(c => EF.Functions.Like(c.DriversLicenseNumber, $"%{pair.Value}%"));
                        foreach (var item in filteredLicenses) { duplicatesResult.Add(item); }
                        break;

                    case "IdNumber":
                        var filteredIds = _db.Clients.Where(c => EF.Functions.Like(c.IdNumber, $"%{pair.Value}%"));
                        foreach (var item in filteredIds) { duplicatesResult.Add(item); }
                        break;

                    case "Pesel":
                        var filteredPesels = _db.Clients.Where(c => EF.Functions.Like(c.Pesel, $"%{pair.Value}%"));
                        foreach (var item in filteredPesels) { duplicatesResult.Add(item); }
                        break;
                }
            }
            int queryCount = 0;
            if (company == null) { company = new Dictionary<string, bool>(); queryCount += company.Count; }
            else { queryCount += company.Count; }
            if (stringQueries == null) { stringQueries = new Dictionary<string, string>(); queryCount += stringQueries.Count; }
            else { queryCount += stringQueries.Count; }

            List<Client> finalResult = duplicatesResult.Distinct().ToList();
            return finalResult.Where(c => c.IsDeleted == false);
        }

        public Client Get(int id)
        {
            return _db.Clients.First(c => c.Id == id);      
        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Clients.Where(c => c.IsDeleted == false);
        }

        public Client Update(int id, Client client)
        {
            var currentRecord = _db.Clients.First(c => c.Id == id);
            foreach (PropertyInfo property in client.GetType().GetProperties())
            {
                var value = client.GetType().GetProperty(property.Name).GetValue(client, null);
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
