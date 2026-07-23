using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.OrderDetailsRepositories
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetailsTbl>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateListOfOrderDetails(List<OrderDetailsTbl> orderDetails)
            => Create(orderDetails);

        public void CreateOrderDetails(OrderDetailsTbl orderDetails) => Create(orderDetails);
        public void DeleteOrderDetails(OrderDetailsTbl orderDetails) => Delete(orderDetails);

        public async Task<IEnumerable<OrderDetailsTbl>> GetAllOrderDetailsAsync()
            => await FindAll().Include(x => x.Order).ThenInclude(x => x.Address).Include(o => o.Product)
                              .Include(o => o.Order).ToListAsync();

        public async Task<IEnumerable<OrderDetailsTbl>> GetOrderDetailsByOrderIdAsync(int orderId)
            => await FindByCondition(o => o.OrderId == orderId).Include(x => x.Order).ThenInclude(x => x.Address).Include(o => o.Product)
                              .Include(o => o.Order).ToListAsync();

        public void UpdateOrderDetails(OrderDetailsTbl orderDetails)
            => Update(orderDetails);

    }

}
