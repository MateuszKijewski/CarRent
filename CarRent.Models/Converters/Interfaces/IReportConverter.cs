using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters.Interfaces
{
    public interface IReportConverter
    {
        ReturnReport AddReturnReportDtoToReturnReport(AddReturnReportDto addReturnReportDto);
        RepairReport AddRepairReportDtoToRepairReport(AddRepairReportDto addRepairReportDto);

        GetReturnReportDto ReturnReportToGetReturnReportDto(ReturnReport returnReport);
        GetRepairReportDto RepairReportToGetRepairReportDto(RepairReport repairReport);
    }
}
