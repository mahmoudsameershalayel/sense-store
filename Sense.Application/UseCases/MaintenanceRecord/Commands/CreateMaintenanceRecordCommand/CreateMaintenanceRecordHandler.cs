using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.CreateMaintenanceRecordCommand
{
    public class CreateMaintenanceRecordHandler : IRequestHandler<CreateMaintenanceRecordCommand, ResponseResult<MaintenanceRecordDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateMaintenanceRecordHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<MaintenanceRecordDto>> Handle(CreateMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaintenanceRecordTbl>(request.Dto);
            _repositoryManager.MaintenanceRecord.CreateMaintenanceRecord(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<MaintenanceRecordDto>(entity);
            return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.Created, dto, $"The Maintenance Record with Id : {entity.Id} created successfully");
        }
    }
}
