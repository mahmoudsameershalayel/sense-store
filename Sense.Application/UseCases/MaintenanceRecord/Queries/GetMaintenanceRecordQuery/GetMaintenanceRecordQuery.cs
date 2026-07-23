using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordQuery
{
    public class GetMaintenanceRecordQuery : IRequest<ResponseResult<MaintenanceRecordDetailDto>>
    {
        public int MaintenanceRecordId { get; set; }
    }
}
