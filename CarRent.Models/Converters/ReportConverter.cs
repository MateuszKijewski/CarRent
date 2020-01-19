using CarRent.Models.Converters.Interfaces;
using CarRent.Models.Dtos.AddDtos;
using CarRent.Models.Dtos.GetDtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters
{
    public class ReportConverter : IReportConverter
    {
        public RepairReport AddRepairReportDtoToRepairReport(AddRepairReportDto addRepairReportDto)
        {
            return new RepairReport
            {
                Description = addRepairReportDto.Description,
                Cost = addRepairReportDto.Cost,
                Time = addRepairReportDto.Time
            };
        }

        public ReturnReport AddReturnReportDtoToReturnReport(AddReturnReportDto addReturnReportDto)
        {
            return new ReturnReport
            {
                DrivenDistance = addReturnReportDto.DrivenDistance,
                IsDamaged = addReturnReportDto.IsDamaged,
                ReturnDate = addReturnReportDto.ReturnDate
            };
        }

        public GetRepairReportDto RepairReportToGetRepairReportDto(RepairReport repairReport)
        {
            return new GetRepairReportDto
            {
                Id = repairReport.Id,
                Description = repairReport.Description,
                Cost = repairReport.Cost,
                Time = repairReport.Time,
                IsDeleted = repairReport.IsDeleted,
                OrderId = repairReport.OrderId
            };
        }

        public GetReturnReportDto ReturnReportToGetReturnReportDto(ReturnReport returnReport)
        {
            return new GetReturnReportDto
            {
                Id = returnReport.Id,
                DrivenDistance = returnReport.DrivenDistance,
                IsDamaged = returnReport.IsDamaged,
                ReturnDate = returnReport.ReturnDate,
                IsDeleted = returnReport.IsDeleted,
                OrderId = returnReport.OrderId
            };
        }
    }
}
