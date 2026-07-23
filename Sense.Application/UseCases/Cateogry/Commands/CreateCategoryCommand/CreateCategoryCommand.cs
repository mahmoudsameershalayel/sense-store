using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<ResponseResult<CategoryDto>>
    {
        public CategoryForCreateUpdateDto? Dto { get; set; }

    }
}