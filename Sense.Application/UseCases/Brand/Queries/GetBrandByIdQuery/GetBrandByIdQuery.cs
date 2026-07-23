using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Queries.GetBrandByIdQuery
{
    public class GetBrandByIdQuery : IRequest<ResponseResult<BrandDto>>
    {
        public int BrandId { get; set; }
    }
}