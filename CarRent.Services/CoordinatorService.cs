using CarRent.Models.Converters.Interfaces;
using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using CarRent.Repositories.Interfaces;
using CarRent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{

    public class CoordinatorService : ICoordinatorService
    {
        private readonly ICoordinatorConverter _coordinatorConverter;
        private readonly ICoordinatorRepository _coordinatorRepository;

        public string Add(AddCoordinatorDto addCoordinatorDto)
        {
            if (!addCoordinatorDto.Validate())
            {
                return "Validation error!";
            }

            var coordinator = _coordinatorConverter.AddCoordinatorDtoToCoordinator(addCoordinatorDto);
            _coordinatorRepository.Add(coordinator);

            return $"Coordinator with id {coordinator.Id} was added successfuly";
        }

        public CoordinatorService(ICoordinatorConverter coordinatorConverter, ICoordinatorRepository coordinatorRepository)
        {
            _coordinatorConverter = coordinatorConverter;
            _coordinatorRepository = coordinatorRepository;
        }


        public GetCoordinatorDto GetCoordinator(int id)
        {
            return _coordinatorConverter.CoordinatorToGetCoordinatorDto(_coordinatorRepository.Get(id));
        }

        public bool ValidateLogin(string login, string password)
        {
            return _coordinatorRepository.ValidateLogin(login, password);
        }
    }
}
