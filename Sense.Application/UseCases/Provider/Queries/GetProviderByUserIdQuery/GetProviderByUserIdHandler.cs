using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Queries.GetProviderByUserIdQuery
{
    public class GetProviderByUserIdHandler : IRequestHandler<GetProviderByUserIdQuery, ResponseResult<ProviderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetProviderByUserIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ProviderDto>> Handle(GetProviderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var provider = await _repositoryManager.Provider.GetProviderByApplicationUserId(request.CurrentUserId);
            if (provider is null)
                return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.NotFound, $"المزود غير موجود!");

            var dto = _mapper.Map<ProviderDto>(provider);
            return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
        }
    }
}
