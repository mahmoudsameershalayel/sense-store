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

namespace Sense.Application.UseCases.Inventory.Queries.GetAllInventoryActionLogsQuery
{
    public class GetAllInventoryActionLogsHandler : IRequestHandler<GetAllInventoryActionLogsQuery, ResponseResult<IEnumerable<InventoryActionDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllInventoryActionLogsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<InventoryActionDto>>> Handle(GetAllInventoryActionLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _repositoryManager.Inventory.GetAllInventoryActionsForItemIdAsync();
            var dtos = _mapper.Map<IEnumerable<InventoryActionDto>>(logs);

            return ResponseResult<IEnumerable<InventoryActionDto>>.GetResult(
                ResultCodeStatus.Success,
                dtos,
                "InventoryActionLogsRetrievedSuccessfully"
            );
        }
    }

}
