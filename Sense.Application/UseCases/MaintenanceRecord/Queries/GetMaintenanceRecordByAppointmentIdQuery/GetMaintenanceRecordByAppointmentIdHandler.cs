using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordByAppointmentIdQuery
{
    public class GetMaintenanceRecordByAppointmentIdHandler : IRequestHandler<GetMaintenanceRecordByAppointmentIdQuery, ResponseResult<MaintenanceRecordDetailDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetMaintenanceRecordByAppointmentIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<MaintenanceRecordDetailDto>> Handle(GetMaintenanceRecordByAppointmentIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByAppointmentIdAsync(request.AppointmentId);
            if (entity is null)
                return ResponseResult<MaintenanceRecordDetailDto>.GetResult(ResultCodeStatus.NotFound, $"The Maintenance Record not exist in the database!!");
            var dto = _mapper.Map<MaintenanceRecordDetailDto>(entity);
            var allFreeMaintenanceOffer = await _repositoryManager.FreeMaintenanceEligibility.GetAllFreeMaintenanceEligibilitysAsync();
            var freeMaintenanceOffer = allFreeMaintenanceOffer.Where(x => x.CustomerId == dto.Appointment.Customer.Id && x.IsActivated && DateTime.UtcNow > x.ActivatedAt && DateTime.UtcNow < x.ExpiresAt).FirstOrDefault();
            if (freeMaintenanceOffer != null)
                dto.IsFreeMaintenanceOfferActive = true;

            return ResponseResult<MaintenanceRecordDetailDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
