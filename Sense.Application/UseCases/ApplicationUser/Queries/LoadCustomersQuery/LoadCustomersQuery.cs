using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CustomerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.LoadCustomersQuery
{
    public class LoadCustomersQuery : IRequest<ResponseResult<IEnumerable<CustomerDto>>>
    {
        public UserParameters? UserParameters { get; set; }
    }
}
