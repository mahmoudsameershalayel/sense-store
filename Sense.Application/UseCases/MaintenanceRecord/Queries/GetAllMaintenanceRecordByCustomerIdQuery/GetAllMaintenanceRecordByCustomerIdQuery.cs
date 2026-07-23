using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordByCustomerIdQuery
{
    public class GetAllMaintenanceRecordByCustomerIdQuery : IRequest<ResponseResult<PagedList<MaintenanceRecordDto>>>
    {
        public string? CurrentUserId { get; set; }
        public MaintenanceRecordParameters MaintenanceRecordParameters { get; set; }

    }
}