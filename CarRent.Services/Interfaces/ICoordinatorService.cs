using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services.Interfaces
{
    public interface ICoordinatorService
    {
        string Add(AddCoordinatorDto addCoordinatorDto);
        GetCoordinatorDto GetCoordinator(int id);
        bool ValidateLogin(string login, string password);
    }
}
