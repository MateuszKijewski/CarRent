using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters.Interfaces
{
    public class CoordinatorConverter : ICoordinatorConverter
    {
        public GetCoordinatorDto CoordinatorToGetCoordinatorDto(Coordinator coordinator)
        {
            return new GetCoordinatorDto
            {
                Login = coordinator.Login,
                IsDeleted = coordinator.IsDeleted,
                Id = coordinator.Id,
                FirstName = coordinator.FirstName,
                LastName = coordinator.LastName,
                PhoneNumber = coordinator.PhoneNumber,
                Email = coordinator.Email,
                FullName = coordinator.FullName()
            };
        }

        public Coordinator AddCoordinatorDtoToCoordinator(AddCoordinatorDto addCoordinatorDto)
        {
            return new Coordinator
            {
                Login = addCoordinatorDto.Login,
                Password = addCoordinatorDto.Password,
                FirstName = addCoordinatorDto.FirstName,
                LastName = addCoordinatorDto.LastName,
                PhoneNumber = addCoordinatorDto.PhoneNumber,
                Email = addCoordinatorDto.Email
            };
        }
    }
}
