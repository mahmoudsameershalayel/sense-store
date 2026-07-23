using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Commands.CreateBrandCommand
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, ResponseResult<BrandDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateBrandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<BrandDto>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BrandTbl>(request.Dto);
            _repositoryManager.Brand.CreateBrand(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<BrandDto>(entity);
            return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.Created, dto, $"The Brand with Id : {entity.Id} created successfully");
        }
    }
}
