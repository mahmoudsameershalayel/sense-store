using Sense.Application.RequestFeatures;
using Sense.Application;
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

namespace Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsForStatisticsQuery
{
    public class GetAllAppointmentsForStatisticsHandler : IRequestHandler<GetAllAppointmentsForStatisticsQuery, ResponseResult<IEnumerable<AppointmentDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllAppointmentsForStatisticsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<AppointmentDto>>> Handle(GetAllAppointmentsForStatisticsQuery request, CancellationToken cancellationToken)
        {
            var allItems = await _repositoryManager.Appointment.GetAllAppointmentsAsync();
            var allDtos = _mapper.Map<List<AppointmentDto>>(allItems);
            return ResponseResult<IEnumerable<AppointmentDto>>.GetResult(ResultCodeStatus.Success, allDtos, "The data retrieved successfully.");
        }
    }
}
