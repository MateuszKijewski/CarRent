using CarRent.Models.Dtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters
{
    public class WorkerConverter : IWorkerConverter
    {
        public Worker FromAddWorkerDtoToWorker(AddWorkerDto addWorkerDto)
        {
            return new Worker
            {
                FirstName = addWorkerDto.FirstName,
                LastName = addWorkerDto.LastName,
                Email = addWorkerDto.Email,
                PhoneNumber = addWorkerDto.PhoneNumber,
                Salary = addWorkerDto.Salary,
            };
        }

        public GetWorkerDto FromWorkerToGetWorkerDto(Worker worker)
        {
            return new GetWorkerDto
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                PhoneNumber = worker.PhoneNumber,
                Email = worker.Email,
                Salary = worker.Salary,
                IsDeleted = worker.IsDeleted,
                CoordinatorId = worker.CoordinatorId,
                CoordinatorName = worker.Coordinator.LastName,

            };         
        }

        public Worker UpdateWorkerDtoToWorker(UpdateWorkerDto updateWorkerDto)
        {
            return new Worker
            {
                FirstName = updateWorkerDto.FirstName,
                LastName = updateWorkerDto.LastName,
                Email = updateWorkerDto.Email,
                PhoneNumber = updateWorkerDto.PhoneNumber,
                Salary = updateWorkerDto.Salary
            };
        }
    }
}
