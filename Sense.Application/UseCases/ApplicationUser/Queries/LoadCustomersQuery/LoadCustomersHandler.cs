using Sense.Application.DomainEntities;
using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.LoadCustomersQuery
{
    public class LoadCustomersHandler : IRequestHandler<LoadCustomersQuery, ResponseResult<IEnumerable<CustomerDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public LoadCustomersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<CustomerDto>>> Handle(LoadCustomersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repositoryManager.ApplicationUser.GetAllCustomersAsync(request.UserParameters);
            var dtos = _mapper.Map<List<CustomerDto>>(users);
            if (request.UserParameters is null)
            {
                var pagedResult = new PagedList<CustomerDto>(dtos);
                return ResponseResult<IEnumerable<CustomerDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data retrieved successfully.");
            }
            var pagedResult1 = new PagedList<CustomerDto>(dtos, users.MetaData.TotalCount, users.MetaData.CurrentPage, users.MetaData.PageSize);
            return ResponseResult<IEnumerable<CustomerDto>>.GetResult(ResultCodeStatus.Success, pagedResult1, "The data retrieved successfully.");
        }
    }

}