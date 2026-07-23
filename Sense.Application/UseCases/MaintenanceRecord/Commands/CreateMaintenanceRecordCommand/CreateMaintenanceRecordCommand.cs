using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.CreateMaintenanceRecordCommand
{
    public class CreateMaintenanceRecordCommand : IRequest<ResponseResult<MaintenanceRecordDto>>
    {
        public MaintenanceRecordForCreateDto Dto { get; set; }
    }
}
