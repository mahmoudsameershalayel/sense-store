using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceProvider.Commands.DeleteServiceProviderCommand
{
    public class DeleteServiceProviderHandler : IRequestHandler<DeleteServiceProviderCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        public DeleteServiceProviderHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteServiceProviderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "المستخدم غير موجود!!");

            var serviceProvider = await _repositoryManager.ServiceProvider.GetServiceProviderByApplicationUserId(user.Id);
            if (serviceProvider is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "مزود الخدمة غير موجود!!");

            var hasServiceListings = await _repositoryManager.ServiceListing.GetAllServiceListingsAsQuery()
                .AnyAsync(s => s.ServiceProviderId == serviceProvider.Id, cancellationToken);
            if (hasServiceListings)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, "لا يمكن حذف مزود الخدمة لوجود خدمات مرتبطة به. يرجى حذف أو نقل خدماته أولاً.");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(" | ", result.Errors.Select(e => e.Description));
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, errors);
            }

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "تم حذف مزود الخدمة بنجاح");
        }
    }
}
