using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordsQuery
{
    public class GetAllMaintenanceRecordsHandler : IRequestHandler<GetAllMaintenanceRecordsQuery, ResponseResult<PagedList<MaintenanceRecordDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllMaintenanceRecordsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<MaintenanceRecordDto>>> Handle(GetAllMaintenanceRecordsQuery request, CancellationToken cancellationToken)
        {
            var itemsWithMetaData = await _repositoryManager.MaintenanceRecord.GetAllMaintenanceRecordsAsync(request.maintenanceRecordParameters);
            var dtos = _mapper.Map<List<MaintenanceRecordDto>>(itemsWithMetaData);
            var pagedResult = new PagedList<MaintenanceRecordDto>(dtos, itemsWithMetaData.MetaData.TotalCount, itemsWithMetaData.MetaData.CurrentPage, itemsWithMetaData.MetaData.PageSize);
            return ResponseResult<PagedList<MaintenanceRecordDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data reterived successfully.");

        }
    }
}
