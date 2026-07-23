using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Inventory.Queries.GetInventoryActionLogsQuery
{
    public class GetInventoryActionLogsHandler : IRequestHandler<GetInventoryActionLogsQuery, ResponseResult<IEnumerable<InventoryActionDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetInventoryActionLogsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<InventoryActionDto>>> Handle(GetInventoryActionLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _repositoryManager.Inventory.GetAllInventoryActionsForItemIdAsync(request.ItemId);
            var dtos = _mapper.Map<IEnumerable<InventoryActionDto>>(logs);

            return ResponseResult<IEnumerable<InventoryActionDto>>.GetResult(
                ResultCodeStatus.Success,
                dtos,
                "InventoryActionLogsRetrievedSuccessfully"
            );
        }
    }

}
