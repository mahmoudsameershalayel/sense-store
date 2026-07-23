using Sense.Application.RequestFeatures;
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

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordByCustomerIdQuery
{
    public class GetAllMaintenanceRecordByCustomerIdHandler : IRequestHandler<GetAllMaintenanceRecordByCustomerIdQuery, ResponseResult<PagedList<MaintenanceRecordDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllMaintenanceRecordByCustomerIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<MaintenanceRecordDto>>> Handle(GetAllMaintenanceRecordByCustomerIdQuery request, CancellationToken cancellationToken)
        {

            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<PagedList<MaintenanceRecordDto>>.GetResult(ResultCodeStatus.NotFound, "The Customer Not Found.");

            var supervisorItemsWithMetaData = await _repositoryManager.MaintenanceRecord.GetCustomerMaintenanceRecordsAsync(request.MaintenanceRecordParameters, customer.Id);
            var dtos = _mapper.Map<List<MaintenanceRecordDto>>(supervisorItemsWithMetaData);
            var pagedResult = new PagedList<MaintenanceRecordDto>(dtos, supervisorItemsWithMetaData.MetaData.TotalCount, supervisorItemsWithMetaData.MetaData.CurrentPage, supervisorItemsWithMetaData.MetaData.PageSize);
            return ResponseResult<PagedList<MaintenanceRecordDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data reterived successfully.");

        }
    }
}
