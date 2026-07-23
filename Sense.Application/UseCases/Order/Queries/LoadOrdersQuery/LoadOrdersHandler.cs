using Sense.Application;
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

namespace Sense.Application.UseCases.Order.Queries.LoadOrdersQuery
{
    public class LoadOrdersHandler : IRequestHandler<LoadOrdersQuery, ResponseResult<IQueryable<OrderTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadOrdersHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<OrderTbl>>> Handle(LoadOrdersQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.Order.GetAllOrdersAsQuery();
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is not null)
                query = query.Where(x => x.CustomerId == customer.Id);
            return ResponseResult<IQueryable<OrderTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
