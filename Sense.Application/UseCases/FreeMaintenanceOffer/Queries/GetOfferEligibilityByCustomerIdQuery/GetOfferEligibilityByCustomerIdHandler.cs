using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetOfferEligibilityByCustomerIdQuery
{
    internal class GetOfferEligibilityByCustomerIdHandler : IRequestHandler<GetOfferEligibilityByCustomerIdQuery, ResponseResult<FreeMaintenanceEligibilityDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetOfferEligibilityByCustomerIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<FreeMaintenanceEligibilityDto>> Handle(GetOfferEligibilityByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var maintenanceEligibility = await _repositoryManager.FreeMaintenanceEligibility.GetFreeMaintenanceEligibilityAsync(request.CustomerId, request.FreeMaintenanceOfferId);
            if (maintenanceEligibility == null)
                return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.NotFound, "العميل ليس لديه تفعيل لهذا العرض!!");
            
            var dto = _mapper.Map<FreeMaintenanceEligibilityDto>(maintenanceEligibility);
            return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.Success, dto, " تم إسترجاع بيانات التفعيل بنجاح");
        }
    }
}
