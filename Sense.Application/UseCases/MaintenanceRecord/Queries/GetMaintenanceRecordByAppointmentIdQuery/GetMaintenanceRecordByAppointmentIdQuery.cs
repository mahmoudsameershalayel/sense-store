using Sense.Application.DomainEntities;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordByAppointmentIdQuery
{
    public class GetMaintenanceRecordByAppointmentIdQuery : IRequest<ResponseResult<MaintenanceRecordDetailDto>>
    {
        public int AppointmentId { get; set; }
    }
}
