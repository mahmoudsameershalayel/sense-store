using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IPointsTransactionRepository
    {
        Task<PointsTransactionTbl> GetPointsTransactionByIdAsync(int id);
        Task<IEnumerable<PointsTransactionTbl>> GetPointsTransactionsByCustomerIdAsync(int customerId);
        Task<IEnumerable<PointsTransactionTbl>> GetAllPointsTransactionsAsync();
        Task<PointsTransactionTbl?> GetPointsTransactionByOrderIdAsync(int orderId);
        Task<PointsTransactionTbl?> GetPointsTransactionByMaintenanceRecordIdAsync(int maintenanceRecordId);
        void CreatePointsTransaction(PointsTransactionTbl pointsTransaction);
        void UpdatePointsTransaction(PointsTransactionTbl pointsTransaction);
        void DeletePointsTransaction(PointsTransactionTbl pointsTransaction);
    }
}