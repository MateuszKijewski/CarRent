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


        public int AddWorker(int coordinatorId, AddWorkerDto addWorkerDto)
        {
            var worker = _workerConverter.FromAddWorkerDtoToWorker(addWorkerDto);
            worker.IsDeleted = false;
            worker.CoordinatorId = coordinatorId;

            _workerRepository.Add(worker);
            return worker.Id;
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
    }
}
