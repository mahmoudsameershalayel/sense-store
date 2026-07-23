using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Queries.GetBannerByIdQuery
{
    public class GetBannerByIdHandler : IRequestHandler<GetBannerByIdQuery, ResponseResult<BannerDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetBannerByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<BannerDto>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Banner.GetHomeBannerByIdAsync(request.BannerId);
            if (entity is null)
                return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.NotFound, $"The Banner with Id : {request.BannerId} not exist in the database!!");
            var dto = _mapper.Map<BannerDto>(entity);
            return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
