using Sense.Application.DomainEntities;
using Sense.Application.DTOs.PointsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Points.Queries.GetPointsTransactionQuery
{
    public class GetPointsTransactionQuery : IRequest<ResponseResult<PointsTransactionDto>>
    {
        public int? OrderId { get; set; }
        public int? MaintenanceRecordId { get; set; }
        public string CurrentUserId { get; set; }
    }
}