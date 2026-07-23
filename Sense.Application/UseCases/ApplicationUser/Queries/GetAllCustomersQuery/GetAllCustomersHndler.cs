using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CustomerDTOs;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetAllCustomersQuery
{
    public class GetAllCustomersHndler : IRequestHandler<GetAllCustomersQuery, ResponseResult<PagedList<CustomerDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllCustomersHndler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            // الحصول على العملاء مع التصفية والتقسيم
            var users = await _repositoryManager.ApplicationUser.GetAllCustomersAsync(request.UserParameters);

            // تحويل العناصر فقط إلى DTO
            var dtoItems = _mapper.Map<List<CustomerDto>>(users.ToList());

            // إنشاء صفحة جديدة بنفس البيانات الوصفية
            var pagedResult = new PagedList<CustomerDto>(
                dtoItems,
                users.MetaData.TotalCount,
                users.MetaData.CurrentPage,
                users.MetaData.PageSize
            );

            return ResponseResult<PagedList<CustomerDto>>.GetResult(
                ResultCodeStatus.Success,
                pagedResult,
                "The data retrieved successfully."
            );
        }
    }

}