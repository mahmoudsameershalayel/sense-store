using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{

    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetailsTbl>> GetAllOrderDetailsAsync();
        Task<IEnumerable<OrderDetailsTbl>> GetOrderDetailsByOrderIdAsync(int orderId);
        void CreateOrderDetails(OrderDetailsTbl orderDetails);
        void UpdateOrderDetails(OrderDetailsTbl orderDetails);
        void CreateListOfOrderDetails(List<OrderDetailsTbl> orderDetails);
        void DeleteOrderDetails(OrderDetailsTbl orderDetails);
    }

}
