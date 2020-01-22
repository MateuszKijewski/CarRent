using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;

namespace CarRent.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerConverter _workerConverter;
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerConverter workerConverter, IWorkerRepository workerRepository)
        {
            _workerConverter = workerConverter;
            _workerRepository = workerRepository;
        }


        public string AddWorker(int coordinatorId, AddWorkerDto addWorkerDto)
        {
            var worker = _workerConverter.FromAddWorkerDtoToWorker(addWorkerDto);
            worker.IsDeleted = false;
            worker.CoordinatorId = coordinatorId;

            _workerRepository.Add(worker);

            return $"Worker with id {worker.Id} was succesfuly deleted";

        }

        public string DeleteWorker(int id)
        {
            _workerRepository.Delete(id);
            return $"Worker with id {id} was succesfuly deleted";
        }

        public IEnumerable<GetWorkerDto> FilterWorkers(Dictionary<string, string> stringQueries, int[] salaryRange)
        {
            return _workerRepository.Filter(stringQueries, salaryRange)
                .Select(w => _workerConverter.FromWorkerToGetWorkerDto(w));
            
        }

        public IEnumerable<GetWorkerDto> GetAllWorkers()
        {
            return _workerRepository.GetAll()
                .Select(w => _workerConverter.FromWorkerToGetWorkerDto(w));
        }

        public GetWorkerDto GetWorker(int id)
        {
            return _workerConverter.FromWorkerToGetWorkerDto(_workerRepository.Get(id));
            
        }
        
        public GetWorkerDto UpdateWorker(int id, UpdateWorkerDto updateWorkerDto)
        {
            var updateWorker = _workerConverter.UpdateWorkerDtoToWorker(updateWorkerDto);
            return _workerConverter.FromWorkerToGetWorkerDto(_workerRepository.Update(id, updateWorker));
        }
    }
}
