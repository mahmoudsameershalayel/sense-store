using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.LoadMaintenanceRecordQuery
{
    public class LoadMaintenanceRecordHandler : IRequestHandler<LoadMaintenanceRecordQuery, ResponseResult<IQueryable<MaintenanceRecordTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadMaintenanceRecordHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<MaintenanceRecordTbl>>> Handle(LoadMaintenanceRecordQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.MaintenanceRecord.GetAllMaintenanceRecordsAsQuery();
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if (supervisor is not null)
                query = query.Where(x => x.SupervisorId == supervisor.Id);
            return ResponseResult<IQueryable<MaintenanceRecordTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
