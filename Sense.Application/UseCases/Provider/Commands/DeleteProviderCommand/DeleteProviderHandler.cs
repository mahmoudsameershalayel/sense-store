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

namespace Sense.Application.UseCases.Provider.Commands.DeleteProviderCommand
{
    public class DeleteProviderHandler : IRequestHandler<DeleteProviderCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        public DeleteProviderHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "المستخدم غير موجود!!");

            var provider = await _repositoryManager.Provider.GetProviderByApplicationUserId(user.Id);
            if (provider is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "المزود غير موجود!!");

            var hasProducts = await _repositoryManager.Product.GetAllProductsAsQuery()
                .AnyAsync(p => p.ProviderId == provider.Id, cancellationToken);
            if (hasProducts)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, "لا يمكن حذف هذا المزود لوجود منتجات مرتبطة به. يرجى حذف أو نقل منتجاته أولاً.");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(" | ", result.Errors.Select(e => e.Description));
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, errors);
            }

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "تم حذف المزود بنجاح");
        }
    }
}
