using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
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

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.ActivateFreeMaintenanceOfferCommand
{
    public class ActivateFreeMaintenanceOfferHandler : IRequestHandler<ActivateFreeMaintenanceOfferCommand, ResponseResult<FreeMaintenanceEligibilityDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ActivateFreeMaintenanceOfferHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<FreeMaintenanceEligibilityDto>> Handle(ActivateFreeMaintenanceOfferCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.Dto.CurrentUserId);
            if (customer is null)
                return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.NotFound, "The User Not Found!!");

            var freeMaintenanceOffer = await _repositoryManager.FreeMaintenanceOffer.GetFreeMaintenanceOfferByIdAsync(request.Dto.OfferId);
            if (freeMaintenanceOffer is null)
                return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.NotFound, "The Free Maintenance Offer Not Found!!");
            var appointments = await _repositoryManager.Appointment.GetAllAppointmentsAsync();
            var customerAppointments = appointments.Where(x => x.CustomerId == customer.Id).ToList();
            var completedAppointments = customerAppointments.Where(x => x.Status == AppointmentStatus.Completed).ToList();

            if (completedAppointments.Count < freeMaintenanceOffer.RequiredAppointments)
                return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.BadRequest, "You have not completed enough appointments!!");

            var eligibility = await _repositoryManager.FreeMaintenanceEligibility.GetFreeMaintenanceEligibilityAsync(customer.Id, freeMaintenanceOffer.Id);
            if (eligibility != null && eligibility.IsActivated)
                return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.BadRequest, "You have already activated this offer!!");

            var now = DateTime.UtcNow;
            var expiresAt = now.AddDays(freeMaintenanceOffer.FreePeriodInDays);
            eligibility = new FreeMaintenanceEligibilityTbl
            {
                CustomerId = customer.Id,
                FreeMaintenanceOfferId = freeMaintenanceOffer.Id,
                IsEligible = true,
                IsActivated = true,
                ActivatedAt = now,
                ExpiresAt = expiresAt
            };

            _repositoryManager.FreeMaintenanceEligibility.CreateFreeMaintenanceEligibility(eligibility);
            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<FreeMaintenanceEligibilityDto>(eligibility);

            return ResponseResult<FreeMaintenanceEligibilityDto>.GetResult(ResultCodeStatus.Success, dto, $"Free maintenance activated! Your free labor period is from {now} to {expiresAt}.");


        }
    }
}
