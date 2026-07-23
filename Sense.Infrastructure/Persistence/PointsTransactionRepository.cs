using Sense.Application.PointsTransactionRepositories;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.PointsTransactionRepositories
{
    public class PointsTransactionRepository : RepositoryBase<PointsTransactionTbl>, IPointsTransactionRepository
    {
        public PointsTransactionRepository(SenseDbContext SenseDbContext) : base(SenseDbContext)
        {
        }

        public void CreatePointsTransaction(PointsTransactionTbl pointsTransaction)
        => Create(pointsTransaction);

        public void DeletePointsTransaction(PointsTransactionTbl pointsTransaction)
        => Delete(pointsTransaction);

        public async Task<PointsTransactionTbl> GetPointsTransactionByIdAsync(int id)
        => await FindByCondition(p => p.Id == id)
            .Include(p => p.Customer)
            .Include(p => p.Order)
            .Include(p => p.MaintenanceRecord)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<PointsTransactionTbl>> GetPointsTransactionsByCustomerIdAsync(int customerId) =>
            await FindByCondition(pt => pt.CustomerId == customerId)
                .Include(pt => pt.Customer)
                .Include(pt => pt.Order)
                .Include(pt => pt.MaintenanceRecord)
                .ToListAsync();

        public async Task<IEnumerable<PointsTransactionTbl>> GetAllPointsTransactionsAsync() =>
            await FindAll()
                .Include(pt => pt.Customer)
                .Include(pt => pt.Order)
                .Include(pt => pt.MaintenanceRecord)
                .ToListAsync();

        public async Task<PointsTransactionTbl?> GetPointsTransactionByOrderIdAsync(int orderId) =>
            await FindByCondition(p => p.OrderId == orderId)
                .FirstOrDefaultAsync();

        public async Task<PointsTransactionTbl?> GetPointsTransactionByMaintenanceRecordIdAsync(int maintenanceRecordId)
        => await FindByCondition(p => p.MaintenanceRecordId == maintenanceRecordId)
            .FirstOrDefaultAsync();

        public void UpdatePointsTransaction(PointsTransactionTbl pointsTransaction)
        => Update(pointsTransaction);
    }
}