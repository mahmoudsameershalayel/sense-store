using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.StatementDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Commands.UpdateStatementCommand
{
    public class UpdateStatementHandler : IRequestHandler<UpdateStatementCommand, ResponseResult<StatementDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateStatementHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<StatementDto>> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Statement.GetStatementByIdAsync(request.Dto.Id);
            if (entity is null)
                return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.NotFound, $"The Statement with Id : {request.Dto.Id} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Statement.UpdateStatement(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<StatementDto>(entity);

            return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.Success, dto, $"The Statement with Id : {request.Dto.Id} updated successfully.");
        }
    }
}
