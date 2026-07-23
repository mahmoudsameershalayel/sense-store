using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceDTOs;
using AutoMapper;
using MediatR;


namespace Sense.Application.UseCases.Service.Commands.UpdateServiceCommand
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, ResponseResult<ServiceDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateServiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.Service.GetServiceByIdAsync(request.ServiceId);
            if (entity is null)
                return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.NotFound, $"The Service with Id : {request.ServiceId} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Service.UpdateService(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<ServiceDto>(entity);

            return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.Success, dto, $"The Service with Id : {request.ServiceId} updated successfully.");
        }
    }
}
