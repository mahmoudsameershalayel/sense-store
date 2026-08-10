using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Commands.ChangeServiceListingStatusCommand
{
    public class ChangeServiceListingStatusHandler : IRequestHandler<ChangeServiceListingStatusCommand, ResponseResult<ServiceListingDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ChangeServiceListingStatusHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        private static bool IsProviderTransitionAllowed(ServiceListingStatus current, ServiceListingStatus target)
            => target == ServiceListingStatus.Published
               && current is ServiceListingStatus.Draft
                   or ServiceListingStatus.PendingReview
                   or ServiceListingStatus.Approved
                   or ServiceListingStatus.Rejected
                   or ServiceListingStatus.Unpublished;

        private static bool IsAdminTransitionAllowed(ServiceListingStatus current, ServiceListingStatus target)
        {
            return target switch
            {
                ServiceListingStatus.Approved => current == ServiceListingStatus.PendingReview,
                ServiceListingStatus.Rejected => current == ServiceListingStatus.PendingReview,
                ServiceListingStatus.Published => current == ServiceListingStatus.Approved || current == ServiceListingStatus.Unpublished || current == ServiceListingStatus.Draft,
                ServiceListingStatus.Unpublished => current == ServiceListingStatus.Published,
                ServiceListingStatus.Archived => current != ServiceListingStatus.Archived,
                ServiceListingStatus.PendingReview => current == ServiceListingStatus.Draft || current == ServiceListingStatus.Rejected,
                _ => false
            };
        }

        public async Task<ResponseResult<ServiceListingDto>> Handle(ChangeServiceListingStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.ServiceListing.GetServiceListingByIdAsync(request.ServiceListingId);
            if (entity is null)
                return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.NotFound, $"الخدمة غير موجودة!");

            if (request.ActingServiceProviderId.HasValue)
            {
                if (entity.ServiceProviderId != request.ActingServiceProviderId)
                    return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.Forbiden, "لا تملك صلاحية على هذه الخدمة!");

                if (!IsProviderTransitionAllowed(entity.Status, request.TargetStatus))
                    return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.BadRequest, "لا يمكن تغيير حالة الخدمة من وضعها الحالي!");
            }
            else
            {
                if (!IsAdminTransitionAllowed(entity.Status, request.TargetStatus))
                    return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.BadRequest, "لا يمكن تغيير حالة الخدمة من وضعها الحالي!");
            }

            entity.Status = request.TargetStatus;
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.ServiceListing.UpdateServiceListing(entity);
            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<ServiceListingDto>(entity);
            return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.Success, dto, "تم تحديث حالة الخدمة بنجاح.");
        }
    }
}
