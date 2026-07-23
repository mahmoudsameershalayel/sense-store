using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CenterSettingDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CenterSetting.Commands.UpdateCenterSettingCommand
{
    public class UpdateCenterSettingCommand : IRequest<ResponseResult<CenterSettingDto>>
    {
        public CenterSettingDto? Dto { get; set; }
    }
}