using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Commands.CreateContactUsCommand
{
    public class CreateContactUsHandler : IRequestHandler<CreateContactUsCommand, ResponseResult<ContactFormTbl>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateContactUsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ContactFormTbl>> Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.ContactUs.CreateContact(request.Contact);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<ContactFormTbl>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            return ResponseResult<ContactFormTbl>.GetResult(ResultCodeStatus.Created, request.Contact, $"The Form with created successfully");
        }
    }
}
