using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Queries.GetAllContactUsQuery
{
    public class GetAllContactUsQuery : IRequest<ResponseResult<IEnumerable<ContactFormTbl>>>
    {
    }
}