using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.LoadInvoicesQuery
{
    public class LoadInvoicesHandler : IRequestHandler<LoadInvoicesQuery, ResponseResult<IQueryable<InvoiceTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadInvoicesHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<InvoiceTbl>>> Handle(LoadInvoicesQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.Invoice.GetAllInvoicesAsQuery();
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if (supervisor is not null)
                query = query.Where(x => x.MaintenanceRecord != null && x.MaintenanceRecord.SupervisorId == supervisor.Id);
            return ResponseResult<IQueryable<InvoiceTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
