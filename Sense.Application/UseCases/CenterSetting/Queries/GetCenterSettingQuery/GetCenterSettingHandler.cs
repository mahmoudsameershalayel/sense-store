using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery
{
    public class GetCenterSettingHandler : IRequestHandler<GetCenterSettingQuery, ResponseResult<CenterSettingDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetCenterSettingHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CenterSettingDto>> Handle(GetCenterSettingQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.CenterSetting.GetCenterSettingAsync();
            if (entity is null)
                return ResponseResult<CenterSettingDto>.GetResult(ResultCodeStatus.NotFound, $"The setting not exist in the database!!");
            var dto = _mapper.Map<CenterSettingDto>(entity);
            return ResponseResult<CenterSettingDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
