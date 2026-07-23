using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.AuthDTOs;
using AutoMapper;
using MediatR;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResponseResult<PagedList<UserDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repositoryManager.ApplicationUser.GetAllUsers(request.UserType, request.UserParameters);

            var dtoItems = _mapper.Map<List<UserDto>>(users.ToList());

            var pagedResult = new PagedList<UserDto>(
                dtoItems,
                users.MetaData.TotalCount,
                users.MetaData.CurrentPage,
                users.MetaData.PageSize
            );

            return ResponseResult<PagedList<UserDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data retrieved successfully.");
        }
    }

}