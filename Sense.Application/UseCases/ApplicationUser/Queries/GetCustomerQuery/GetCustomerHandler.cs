using Sense.Application;
using Sense.Domain.DBEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.IsCustomerQuery
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerTbl>
    {
        private readonly IRepositoryManager _repositoryManager;
        public GetCustomerHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<CustomerTbl> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.UserId);
            return customer;
        }
    }
}
