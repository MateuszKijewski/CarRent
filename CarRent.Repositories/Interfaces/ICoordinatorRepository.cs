using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Repositories.Interfaces
{
    public interface ICoordinatorRepository
    {
        Coordinator Get(int id);
        int Add(Coordinator coordinator);
        bool ValidateLogin(string login, string password);
    }
}
