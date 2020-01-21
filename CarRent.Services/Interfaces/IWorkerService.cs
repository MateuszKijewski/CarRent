﻿using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface IWorkerService
    {
        int AddWorker(int coordinatorId, AddWorkerDto addWorkerDto);
        GetWorkerDto GetWorker(int id);
        string DeleteWorker(int id);
        IEnumerable<GetWorkerDto> GetAllWorkers();
        IEnumerable<GetWorkerDto> FilterWorkers(Dictionary<string, string> stringQueries, int[] salaryRange);
        GetWorkerDto UpdateWorker(int id, UpdateWorkerDto updateWorkerDto);

    }
}
