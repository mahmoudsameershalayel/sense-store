using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Commands.CreateBrandCommand
{
    public class CreateBrandCommand : IRequest<ResponseResult<BrandDto>>
    {
        public BrandForCreateUpdateDto? Dto { get; set; }

    }
}