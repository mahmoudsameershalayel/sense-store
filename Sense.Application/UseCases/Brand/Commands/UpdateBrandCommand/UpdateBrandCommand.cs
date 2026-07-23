using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Commands.UpdateBrandCommand
{
    public class UpdateBrandCommand : IRequest<ResponseResult<BrandDto>>
    {
        public int BrandId { get; set; }
        public BrandForCreateUpdateDto? Dto { get; set; }

    }
}