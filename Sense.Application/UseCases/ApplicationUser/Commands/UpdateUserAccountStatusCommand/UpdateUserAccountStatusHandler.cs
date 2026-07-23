using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand
{
    public class UpdateUserAccountStatusHandler : IRequestHandler<UpdateUserAccountStatusCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateUserAccountStatusHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateUserAccountStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if(user is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"المستخدم غير موجود!!");

            user.IsActive = !user.IsActive; 


            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"تم تحديث حالة المستخدم بنجاح");
            }
            return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"فشلت العملية!!");
        }


    }
}
