using Sense.Application.RequestFeatures;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.OrderRepositories
{
    public class OrderRepository : RepositoryBase<OrderTbl>, IOrderRepository
    {
        private readonly SenseDbContext _context;
        public OrderRepository(SenseDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PagedList<OrderTbl>> GetAllOrdersAsync(OrderParameters orderParameters)
        {
            var query = FindAll()
                           .Include(x => x.OrderDetails)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Category)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Brand)
                           .Include(x => x.OrderDetails)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Model)
                           .Include(x => x.Customer)
                           .ThenInclude(x => x.ApplicationUser)
                           .Include(x => x.Address)
                           .AsQueryable();

            // Apply filters based on the request parameters
            if (orderParameters.StartDate.HasValue)
            {
                query = query.Where(o => o.OrderDate >= orderParameters.StartDate.Value);
            }

            if (orderParameters.EndDate.HasValue)
            {
                query = query.Where(o => o.OrderDate <= orderParameters.EndDate.Value);
            }

            if (orderParameters.Status.HasValue)
            {
                query = query.Where(o => o.OrderStatus.Equals(orderParameters.Status));
            }
            if (orderParameters.IsActive)
            {
                query = query.Where(o => o.OrderStatus.Equals(OrderStatus.Pending) || o.OrderStatus.Equals(OrderStatus.Prepared) || o.OrderStatus.Equals(OrderStatus.Preparing) || o.OrderStatus.Equals(OrderStatus.OutForDelivery));
            }
            if (orderParameters.IsHistory)
            {
                query = query.Where(o => o.OrderStatus.Equals(OrderStatus.Deliverd) || o.OrderStatus.Equals(OrderStatus.Deliverd) || o.OrderStatus.Equals(OrderStatus.Rejected));
            }

            if (orderParameters.CustomerId.HasValue)
            {
                query = query.Where(o => o.CustomerId == orderParameters.CustomerId.Value);
            }

            // Apply sorting (e.g., by order date)
            query = query.OrderByDescending(o => o.OrderDate);

            // Return the results with pagination
            var orders = await query.ToListAsync();

            return PagedList<OrderTbl>.ToPagedList(orders, orderParameters.PageNumber, orderParameters.PageSize);
        }
        public async Task<IEnumerable<OrderTbl>> GetAllOrdersAsync()
        => await FindAll()
                           .Include(x => x.OrderDetails)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Category)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Brand)
                           .Include(x => x.OrderDetails)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Model)
                           .Include(x => x.Customer)
                           .ThenInclude(x => x.ApplicationUser)
                           .Include(x => x.Address)
                           .ToListAsync();


        public async Task<PagedList<OrderTbl>> GetMyAllOrdersAsync(int customerId, OrderParameters orderParameters)
        {
            var query = FindAll()
                           .Include(x => x.OrderDetails)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Category)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Brand)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Model)
                           .Include(x => x.OrderDetails)
                           .Include(x => x.Customer)
                           .ThenInclude(x => x.ApplicationUser)
                           .Include(x => x.Address)
                           .AsQueryable();

            // Apply filters based on the request parameters
            if (customerId != 0)
            {
                query = query.Where(o => o.CustomerId == customerId);
            }
            if (orderParameters.StartDate.HasValue)
            {
                query = query.Where(o => o.OrderDate >= orderParameters.StartDate.Value);
            }

            if (orderParameters.EndDate.HasValue)
            {
                query = query.Where(o => o.OrderDate <= orderParameters.EndDate.Value);
            }

            if (orderParameters.Status.HasValue)
            {
                query = query.Where(o => o.OrderStatus.Equals(orderParameters.Status));
            }
            if (orderParameters.IsActive)
            {
                query = query.Where(o => o.OrderStatus.Equals(OrderStatus.Pending)|| o.OrderStatus.Equals(OrderStatus.Prepared) || o.OrderStatus.Equals(OrderStatus.Preparing) || o.OrderStatus.Equals(OrderStatus.OutForDelivery));
            }
            if (orderParameters.IsHistory)
            {
                query = query.Where(o => o.OrderStatus.Equals(OrderStatus.Rejected) || o.OrderStatus.Equals(OrderStatus.Deliverd) || o.OrderStatus.Equals(OrderStatus.Deliverd));
            }

            if (orderParameters.CustomerId.HasValue)
            {
                query = query.Where(o => o.CustomerId == orderParameters.CustomerId.Value);
            }

            // Apply sorting (e.g., by order date)
            query = query.OrderByDescending(o => o.OrderDate);

            // Return the results with pagination
            var orders = await query.ToListAsync();

            return PagedList<OrderTbl>.ToPagedList(orders, orderParameters.PageNumber, orderParameters.PageSize);
        }

        public async Task<OrderTbl> GetOrderById(long id) => await FindByCondition(x => x.Id == id)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Category)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Brand)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Model)
                           .Include(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                           .Include(x => x.Address)
                           .Include(x => x.CashbackUsages).ThenInclude(x => x.CashbackOffer)
                           .FirstOrDefaultAsync();

        public void CreateOrderAll(OrderTbl orderAll) => Create(orderAll);
        public async Task DeleteOrderAsync(long orderId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var orderDetails = await _context.OrderDetailsTbls
                    .Where(d => d.OrderId == orderId)
                    .ToListAsync();
                _context.OrderDetailsTbls.RemoveRange(orderDetails);

                var orders = await _context.OrderDetailsTbls
                    .Where(o => o.OrderId == orderId)
                    .ToListAsync();
                _context.OrderDetailsTbls.RemoveRange(orders);

                var orderAll = await _context.OrderTbls
                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (orderAll != null)
                {
                    _context.OrderTbls.Remove(orderAll);
                }

                // Commit the transaction after all entities have been removed
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // Rollback in case of any error to maintain data integrity
                await transaction.RollbackAsync();
                throw new InvalidOperationException("An error occurred while deleting the order.", ex);
            }
        }
        public async Task ClearAllOrdersAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var allOrderDetails = await _context.OrderDetailsTbls.ToListAsync();
                _context.OrderDetailsTbls.RemoveRange(allOrderDetails);



                var allOrdersAll = await _context.OrderTbls.ToListAsync();
                _context.OrderTbls.RemoveRange(allOrdersAll);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException("An error occurred while clearing all orders.", ex);
            }
        }


        public void UpdateOrderAll(OrderTbl order) => Update(order);

        public Task<List<OrderTbl>> GetMyAllOrdersAsync(long customerId) => FindByCondition(x => x.CustomerId == customerId)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Category)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Brand)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Model)
                           .Include(x => x.OrderDetails)
                           .Include(x => x.Customer)
                           .ThenInclude(x => x.ApplicationUser)
                           .Include(x => x.Address)
                           .ToListAsync();

        public async Task<List<OrderTbl>> GetOrdersByIds(HashSet<long> ids)
            => await FindByCondition(x => ids.Contains(x.Id))
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Category)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Brand)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Model)
                           .Include(x => x.OrderDetails)
                           .Include(x => x.Customer)
                           .ThenInclude(x => x.ApplicationUser)
                           .Include(x => x.Address)
                           .ToListAsync();

        public IQueryable<OrderTbl> GetAllOrdersAsQuery()
             => FindAll().Include(x => x.OrderDetails)
                          .ThenInclude(x => x.Product)
                          .ThenInclude(x => x.Category)
                          .Include(x => x.OrderDetails)
                          .ThenInclude(x => x.Product)
                          .ThenInclude(x => x.Brand)
                          .Include(x => x.OrderDetails)
                          .ThenInclude(x => x.Product)
                          .ThenInclude(x => x.Model)
                          .Include(x => x.OrderDetails)
                          .Include(x => x.Customer)
                          .ThenInclude(x => x.ApplicationUser)
                          .Include(x => x.Address)
                          .OrderByDescending(x => x.OrderDate)
                          .AsQueryable();
    }

}
