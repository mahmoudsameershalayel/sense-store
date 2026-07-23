using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.DeleteMaintenanceRecordCommand
{
    public class DeleteMaintenanceRecordCommand : IRequest<ResponseResult<bool>>
    {
        public int MaintenanceRecordId { get; set; }
    }
}