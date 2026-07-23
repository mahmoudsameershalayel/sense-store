using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ResponseResult<CategoryDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateCategoryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.Category.GetCategoryByIdAsync(request.Dto.Id);
            if (entity is null)
                return ResponseResult<CategoryDto>.GetResult(ResultCodeStatus.NotFound, $"The category with Id : {request.Dto.Id} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Category.UpdateCategory(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<CategoryDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<CategoryDto>(entity);

            return ResponseResult<CategoryDto>.GetResult(ResultCodeStatus.Success, dto, $"The category with Id : {request.Dto.Id} updated successfully.");
        }
    }
}
