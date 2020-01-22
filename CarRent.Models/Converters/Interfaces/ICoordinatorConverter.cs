using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters.Interfaces
{
    public interface ICoordinatorConverter
    {
        GetCoordinatorDto CoordinatorToGetCoordinatorDto(Coordinator coordinator);
        Coordinator AddCoordinatorDtoToCoordinator(AddCoordinatorDto addCoordinatorDto);
    }
}
