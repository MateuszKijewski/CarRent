using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface IWorkerService
    {
        int AddWorker(int coordinatorId, int regionid, AddWorkerDto addWorkerDto);
        GetWorkerDto GetWorker(int id);
        IEnumerable<GetWorkerDto> GetAllWorkers();
        IEnumerable<GetWorkerDto> FilterWorkers(Dictionary<string, string> stringQueries, int[] salaryRange);

    }
}
