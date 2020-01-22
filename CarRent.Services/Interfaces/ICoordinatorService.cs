using CarRent.Models.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services.Interfaces
{
    public interface ICoordinatorService
    {
        GetCoordinatorDto GetCoordinator(int id);
        bool ValidateLogin(string login, string password);
    }
}
