using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ModelDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Commands.UpdateModelCommand
{
    public class UpdateModelHandler : IRequestHandler<UpdateModelCommand, ResponseResult<ModelDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateModelHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ModelDto>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.Model.GetBrandTypeByIdAsync(request.ModelId);
            if (entity is null)
                return ResponseResult<ModelDto>.GetResult(ResultCodeStatus.NotFound, $"The brand type with Id : {request.ModelId} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Model.UpdateBrandType(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<ModelDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<ModelDto>(entity);

            return ResponseResult<ModelDto>.GetResult(ResultCodeStatus.Success, dto, $"The brand type with Id : {request.ModelId} updated successfully.");
        }
    }
}