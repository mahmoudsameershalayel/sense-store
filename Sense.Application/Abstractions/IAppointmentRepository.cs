using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IAppointmentRepository
    {
        IQueryable<AppointmentTbl> GetAllAppointmentsAsQuery();
        Task<PagedList<AppointmentTbl>> GetAllAppointmentsAsync(AppointmentParameters appointmentParameters);
        Task<PagedList<AppointmentTbl>> GetAllAppointmentsAsync(AppointmentParameters appointmentParameters , int customerId);
        Task<PagedList<AppointmentTbl>> GetAllSupervisorAppointmentsAsync(AppointmentParameters appointmentParameters , int supervisorId);
        Task<List<AppointmentTbl>> GetAllAppointmentsAsync();
        Task<AppointmentTbl> GetAppointmentByIdAsync(int id);
        void CreateAppointment(AppointmentTbl appointment);           
        void UpdateAppointment(AppointmentTbl appointment);
        void DeleteAppointment(AppointmentTbl appointment);
    }
}
