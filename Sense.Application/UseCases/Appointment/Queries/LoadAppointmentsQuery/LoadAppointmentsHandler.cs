using Sense.Application.DomainEntities;
using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
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

namespace Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery
{
    public class LoadAppointmentsHandler : IRequestHandler<LoadAppointmentsQuery, ResponseResult<IQueryable<AppointmentTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadAppointmentsHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<AppointmentTbl>>> Handle(LoadAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.Appointment.GetAllAppointmentsAsQuery();
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if (supervisor is not null)
                query = query.Where(x => x.SupervisorId == supervisor.Id);
            return ResponseResult<IQueryable<AppointmentTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
