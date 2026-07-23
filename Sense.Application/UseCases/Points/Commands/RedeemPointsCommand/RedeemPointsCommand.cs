using Sense.Application.DomainEntities;
using Sense.Application.DTOs.PointsDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Points.Commands.RedeemPointsCommand
{
    public class RedeemPointsCommand : IRequest<ResponseResult<RedeemPointsResultDto>>
    {
        public RedeemPointsDto? Dto { get; set; }
    }
}