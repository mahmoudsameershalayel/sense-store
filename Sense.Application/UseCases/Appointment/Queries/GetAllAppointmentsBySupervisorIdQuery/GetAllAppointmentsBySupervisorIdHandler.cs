using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsBySupervisorIdQuery
{
    public class GetAllAppointmentsBySupervisorIdHandler : IRequestHandler<GetAllAppointmentsBySupervisorIdQuery, ResponseResult<PagedList<AppointmentDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllAppointmentsBySupervisorIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<AppointmentDto>>> Handle(GetAllAppointmentsBySupervisorIdQuery request, CancellationToken cancellationToken)
        {
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if (supervisor is null)
                return ResponseResult<PagedList<AppointmentDto>>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");
            var supervisorItemsWithMetaData = await _repositoryManager.Appointment.GetAllSupervisorAppointmentsAsync(request.AppointmentParameters, supervisor.Id);

            var dtos = _mapper.Map<List<AppointmentDto>>(supervisorItemsWithMetaData);

            var pagedResult = new PagedList<AppointmentDto>(dtos, supervisorItemsWithMetaData.MetaData.TotalCount, supervisorItemsWithMetaData.MetaData.CurrentPage, supervisorItemsWithMetaData.MetaData.PageSize);

            return ResponseResult<PagedList<AppointmentDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data retrieved successfully.");
        }
    }
}
