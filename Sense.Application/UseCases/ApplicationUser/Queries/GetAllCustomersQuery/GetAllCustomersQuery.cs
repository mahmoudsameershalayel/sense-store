using Sense.Application.RequestFeatures;
using MediatR;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CustomerDTOs;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetAllCustomersQuery
{
    public class GetAllCustomersQuery : IRequest<ResponseResult<PagedList<CustomerDto>>>
    {
        public UserParameters? UserParameters { get; set; }
    }

}
