using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IOrderRepository
    {
        IQueryable<OrderTbl> GetAllOrdersAsQuery();
        Task<PagedList<OrderTbl>> GetAllOrdersAsync(OrderParameters orderParameters);
        Task<IEnumerable<OrderTbl>> GetAllOrdersAsync();
        Task<PagedList<OrderTbl>> GetMyAllOrdersAsync(int customerId, OrderParameters orderParameters);

        Task<List<OrderTbl>> GetMyAllOrdersAsync(long customerId);
        Task<OrderTbl> GetOrderById(long id);
        Task<List<OrderTbl>> GetOrdersByIds(HashSet<long> ids);
        void UpdateOrderAll(OrderTbl order);
        void CreateOrderAll(OrderTbl orderAll);
        Task DeleteOrderAsync(long orderId);

        Task ClearAllOrdersAsync();
    }
}
