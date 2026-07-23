using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordQuery
{
    public class GetMaintenanceRecordHandler : IRequestHandler<GetMaintenanceRecordQuery, ResponseResult<MaintenanceRecordDetailDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetMaintenanceRecordHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<MaintenanceRecordDetailDto>> Handle(GetMaintenanceRecordQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByIdAsync(request.MaintenanceRecordId);
            if (entity is null)
                return ResponseResult<MaintenanceRecordDetailDto>.GetResult(ResultCodeStatus.NotFound, $"The Maintenance Record with Id : {request.MaintenanceRecordId} not exist in the database!!");
            
            var dto = _mapper.Map<MaintenanceRecordDetailDto>(entity);
            var now = DateTime.UtcNow;
            var allFreeMaintenanceOffer = await _repositoryManager.FreeMaintenanceEligibility.GetAllFreeMaintenanceEligibilitysAsync();

            var freeMaintenanceOffer = allFreeMaintenanceOffer
       .Where(x =>
           x.CustomerId == dto.Appointment.Customer.Id &&
           x.IsActivated &&
           now > x.ActivatedAt &&
           now < x.ExpiresAt &&
           entity.Appointment.CreatedAt >= x.ActivatedAt &&
           entity.Appointment.CreatedAt <= x.ExpiresAt
       ).FirstOrDefault();
            
            dto.IsFreeMaintenanceOfferActive = freeMaintenanceOffer != null;
            
            // Map the free maintenance eligibility data if it exists
            if (freeMaintenanceOffer != null)
            {
                dto.FreeMaintenanceEligibility = _mapper.Map<DTOs.FreeMaintenanceEligibilityDTOs.FreeMaintenanceEligibilityDto>(freeMaintenanceOffer);
            }

            // Get points transaction if exists
            var pointsTransaction = await _repositoryManager.PointsTransaction.GetPointsTransactionByMaintenanceRecordIdAsync(request.MaintenanceRecordId);
            if (pointsTransaction != null)
            {
                dto.PointsTransaction = _mapper.Map<DTOs.PointsDTOs.PointsTransactionDto>(pointsTransaction);
            }

            return ResponseResult<MaintenanceRecordDetailDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
