using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ModelDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Queries.GetModelsByBrandIdQuery
{
    public class GetModelsByBrandIdQuery : IRequest<ResponseResult<IEnumerable<ModelDto>>>
    {
        public int BrandId { get; set; }
    }
}