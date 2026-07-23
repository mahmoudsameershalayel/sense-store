using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.UpdateMaintenanceRecordCommand
{
    public class UpdateMaintenanceRecordHandler : IRequestHandler<UpdateMaintenanceRecordCommand, ResponseResult<MaintenanceRecordDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateMaintenanceRecordHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<MaintenanceRecordDto>> Handle(UpdateMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByIdAsync(request.MaintenanceRecordId);
            if (entity is null)
                return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.NotFound, $"The Maintenance Record with Id : {request.MaintenanceRecordId} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.MaintenanceRecord.UpdateMaintenanceRecord(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<MaintenanceRecordDto>(entity);

            return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.Success, dto, $"The Maintenance Record with Id : {request.MaintenanceRecordId} updated successfully.");
        }
    }
}
