using Sense.Domain.DBEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.IsCustomerQuery
{
    public class GetCustomerQuery : IRequest<CustomerTbl>
    {
        public string UserId { get; set; }
    }
}
