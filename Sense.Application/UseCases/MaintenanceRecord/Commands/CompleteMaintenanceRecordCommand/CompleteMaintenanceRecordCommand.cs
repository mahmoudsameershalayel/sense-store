using Sense.Application.DomainEntities;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.CompleteMaintenanceRecordCommand
{
    public class CompleteMaintenanceRecordCommand : IRequest<ResponseResult<MaintenanceRecordDto>>
    {
        public int MaintenanceRecordId { get; set; }
        //public Dictionary<long, decimal>? LaborCosts{ get; set; }
        public List<CompleteMaintenanceRecordDto>? Dtos { get; set; }
       
    }
}
