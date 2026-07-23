using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.DeleteMaintenanceRecordCommand
{
    public class DeleteMaintenanceRecordHandler : IRequestHandler<DeleteMaintenanceRecordCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public DeleteMaintenanceRecordHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByIdAsync(request.MaintenanceRecordId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Maintenance Record with Id : {request.MaintenanceRecordId} not exist in the database!!");

            _repositoryManager.MaintenanceRecord.DeleteMaintenanceRecord(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Maintenance Record with Id : {request.MaintenanceRecordId} deleted successfully");
        }
    }
}
