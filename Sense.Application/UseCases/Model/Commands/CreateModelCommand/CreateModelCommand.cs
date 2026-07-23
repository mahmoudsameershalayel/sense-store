using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.ModelDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Commands.CreateModelCommand
{
    public class CreateModelCommand : IRequest<ResponseResult<ModelDto>>
    {
        public ModelForCreateUpdateDto? Dto { get; set; }

    }
}