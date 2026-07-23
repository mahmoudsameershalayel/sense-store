using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum ActivityType
    {
        ApprovedMaintenance = 1,
        CreatedInvoice = 2,
        RejectedMaintenance = 5,
        ReceiveAppointment = 6,
        RejecteAppointment = 3,
        UpdatedAppointment = 4,
        CompleteAppointment = 7,
        CompleteMaintenanceRecord = 8
    }
}
