using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordsQuery
{
    public class GetAllMaintenanceRecordsQuery : IRequest<ResponseResult<PagedList<MaintenanceRecordDto>>>
    {
        public string CurrentUserId { get; set; }
        public MaintenanceRecordParameters maintenanceRecordParameters { get; set; }
    }

}