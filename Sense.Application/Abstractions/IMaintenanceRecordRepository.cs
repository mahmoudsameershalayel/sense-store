using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IMaintenanceRecordRepository
    {
        IQueryable<MaintenanceRecordTbl> GetAllMaintenanceRecordsAsQuery();
        Task<PagedList<MaintenanceRecordTbl>> GetAllMaintenanceRecordsAsync(MaintenanceRecordParameters parameters);
        Task<PagedList<MaintenanceRecordTbl>> GetSupervisorMaintenanceRecordsAsync(MaintenanceRecordParameters parameters , int supervisorId);
        Task<PagedList<MaintenanceRecordTbl>> GetCustomerMaintenanceRecordsAsync(MaintenanceRecordParameters parameters , int customerId);
        Task<MaintenanceRecordTbl> GetMaintenanceRecordByIdAsync(int id);
        Task<MaintenanceRecordTbl> GetMaintenanceRecordByAppointmentIdAsync(int appointmentId);
        void CreateMaintenanceRecord(MaintenanceRecordTbl maintenanceRecord);
        void UpdateMaintenanceRecord(MaintenanceRecordTbl maintenanceRecord);
        void DeleteMaintenanceRecord(MaintenanceRecordTbl maintenanceRecord);
    }
}
