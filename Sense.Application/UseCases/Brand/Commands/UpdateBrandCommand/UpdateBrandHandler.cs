using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Commands.UpdateBrandCommand
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, ResponseResult<BrandDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateBrandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<BrandDto>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.Brand.GetBrandByIdAsync(request.BrandId);
            if (entity is null)
                return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.NotFound, $"The brand with Id : {request.BrandId} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Brand.UpdateBrand(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<BrandDto>(entity);

            return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.Success, dto, $"The brand with Id : {request.BrandId} updated successfully.");
        }
    }
}
