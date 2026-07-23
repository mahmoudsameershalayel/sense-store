using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CustomerDTOs;

namespace Sense.Application.UseCases.ActivityLog.Queries.GenerateCustomerReportQuery
{
    public class GenerateCustomerReportQuery : IRequest<ResponseResult<CustomerReportDto>>
    {
        public string CustomerId { get; set; }
    }
}
