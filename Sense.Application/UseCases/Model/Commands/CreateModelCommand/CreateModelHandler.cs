using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.ModelDTOs;
using Sense.Application.UseCases.Brand.Commands.CreateBrandCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Commands.CreateModelCommand
{
    public class CreateModelHandler : IRequestHandler<CreateModelCommand, ResponseResult<ModelDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateModelHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ModelDto>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ModelTbl>(request.Dto);
            _repositoryManager.Model.CreateBrandType(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<ModelDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<ModelDto>(entity);
            return ResponseResult<ModelDto>.GetResult(ResultCodeStatus.Created, dto, $"The Model with Id : {entity.Id} created successfully");
        }
    }
}
