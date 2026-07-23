using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.CreateFreeMaintenanceOfferCommand
{
    public class CreateFreeMaintenanceOfferHandler : IRequestHandler<CreateFreeMaintenanceOfferCommand, ResponseResult<FreeMaintenanceOfferDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateFreeMaintenanceOfferHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<FreeMaintenanceOfferDto>> Handle(CreateFreeMaintenanceOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FreeMaintenanceOfferTbl>(request.Dto);
            _repositoryManager.FreeMaintenanceOffer.CreateFreeMaintenanceOffer(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<FreeMaintenanceOfferDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<FreeMaintenanceOfferDto>(entity);
            return ResponseResult<FreeMaintenanceOfferDto>.GetResult(ResultCodeStatus.Created, dto, $"The Free Maintenance Offer with Id : {entity.Id} created successfully");
        }
    }
}