using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CenterSetting.Commands.UpdateCenterSettingCommand
{
    public class UpdateCenterSettingHandler : IRequestHandler<UpdateCenterSettingCommand, ResponseResult<CenterSettingDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateCenterSettingHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CenterSettingDto>> Handle(UpdateCenterSettingCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.CenterSetting.GetCenterSettingAsync();
            if (entity is null)
            {
                var setting = _mapper.Map<CenterSettingTbl>(request.Dto);
                _repositoryManager.CenterSetting.CreateCenterSetting(setting);
                await _repositoryManager.SaveAsync();
                return ResponseResult<CenterSettingDto>.GetResult(ResultCodeStatus.Success, $"The setting not exist in the database!!");
            }

            _mapper.Map(request.Dto, entity);
            _repositoryManager.CenterSetting.UpdateCenterSetting(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<CenterSettingDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<CenterSettingDto>(entity);

            return ResponseResult<CenterSettingDto>.GetResult(ResultCodeStatus.Success, dto, $"The setting not exist in the database!!");
        }
    }
}
