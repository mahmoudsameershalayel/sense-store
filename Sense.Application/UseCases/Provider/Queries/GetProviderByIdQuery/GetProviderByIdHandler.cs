using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Queries.GetProviderByIdQuery
{
    public class GetProviderByIdHandler : IRequestHandler<GetProviderByIdQuery, ResponseResult<ProviderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;
        public GetProviderByIdHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ProviderDto>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var provider = await _repositoryManager.Provider.GetProviderByIdAsync(request.Id);
            if (provider is null || provider.IsDeleted)
                return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.NotFound, $"المزود غير موجود!");

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == provider.ApplicationUserId && x.UserType == UserType.Provider, cancellationToken);
            if (user is null)
                return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.NotFound, $"المزود غير موجود!");

            var dto = _mapper.Map<ProviderDto>(provider);
            dto.Email = user.Email;
            dto.PhoneNumber = user.PhoneNumber;
            dto.LogoURL = provider.LogoURL ?? user.ImageURL;
            dto.IsActive = user.IsActive;

            return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
        }
    }
}
