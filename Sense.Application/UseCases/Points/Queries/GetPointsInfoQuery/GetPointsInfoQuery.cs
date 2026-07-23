using Sense.Application.DomainEntities;
using Sense.Application.DTOs.PointsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Points.Queries.GetPointsInfoQuery
{
    public class GetPointsInfoQuery : IRequest<ResponseResult<PointsInfoDto>>
    {
        public string CurrentUserId { get; set; }
        public int? OrderId { get; set; }
        public int? MaintenanceRecordId { get; set; }
    }
}