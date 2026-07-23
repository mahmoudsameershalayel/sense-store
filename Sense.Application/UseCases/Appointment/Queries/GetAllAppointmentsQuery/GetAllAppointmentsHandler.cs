using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.ProductDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsQuery
{
    public class GetAllAppointmentsHandler : IRequestHandler<GetAllAppointmentsQuery, ResponseResult<PagedList<AppointmentDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllAppointmentsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<AppointmentDto>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.CurrentUserId))
            {
                var allItemsWithMetaData = await _repositoryManager.Appointment.GetAllAppointmentsAsync(request.AppointmentParameters);
                // Map the filtered items to AppointmentDto
                var allDtos = _mapper.Map<List<AppointmentDto>>(allItemsWithMetaData);

                // Pagination metadata
                var allTotalAppointmentsCount = allItemsWithMetaData.Count(); // Total filtered items count

                // Add metadata to the response
                var allPagedResult = new PagedList<AppointmentDto>(allDtos, allItemsWithMetaData.MetaData.TotalCount, allItemsWithMetaData.MetaData.CurrentPage, allItemsWithMetaData.MetaData.PageSize);

                // Return the response with metadata and data
                return ResponseResult<PagedList<AppointmentDto>>.GetResult(ResultCodeStatus.Success, allPagedResult, "The data retrieved successfully.");
            }
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<PagedList<AppointmentDto>>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");

            var customerItemsWithMetaData = await _repositoryManager.Appointment.GetAllAppointmentsAsync(request.AppointmentParameters , customer.Id);

            var dtos = _mapper.Map<List<AppointmentDto>>(customerItemsWithMetaData);

            var pagedResult = new PagedList<AppointmentDto>(dtos, customerItemsWithMetaData.MetaData.TotalCount, customerItemsWithMetaData.MetaData.CurrentPage, customerItemsWithMetaData.MetaData.PageSize);

            return ResponseResult<PagedList<AppointmentDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data retrieved successfully.");
        }
    }
}
