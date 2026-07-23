using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Commands.CreateServiceCommand
{
    public class CreateServiceCommand : IRequest<ResponseResult<ServiceDto>>
    {
        public ServiceForCreateUpdateDto? Dto { get; set; }

    }
}