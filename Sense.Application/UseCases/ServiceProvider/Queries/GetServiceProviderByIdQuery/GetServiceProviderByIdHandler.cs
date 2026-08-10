using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceProviderDTOs;
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

namespace Sense.Application.UseCases.ServiceProvider.Queries.GetServiceProviderByIdQuery
{
    public class GetServiceProviderByIdHandler : IRequestHandler<GetServiceProviderByIdQuery, ResponseResult<ServiceProviderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;
        public GetServiceProviderByIdHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceProviderDto>> Handle(GetServiceProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceProvider = await _repositoryManager.ServiceProvider.GetServiceProviderByIdAsync(request.Id);
            if (serviceProvider is null || serviceProvider.IsDeleted)
                return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.NotFound, $"مزود الخدمة غير موجود!");

            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == serviceProvider.ApplicationUserId && x.UserType == UserType.ServiceProvider, cancellationToken);
            if (user is null)
                return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.NotFound, $"مزود الخدمة غير موجود!");

            var dto = _mapper.Map<ServiceProviderDto>(serviceProvider);
            dto.Email = user.Email;
            dto.PhoneNumber = user.PhoneNumber;
            dto.LogoURL = serviceProvider.LogoURL ?? user.ImageURL;
            dto.IsActive = user.IsActive;

            return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
        }
    }
}
