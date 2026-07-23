using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum MaintenanceStatus
    {
        [Display(Name = "تحت الصيانة")]
        UnderMaintenance = 1,
        [Display(Name = "مكتمل")]
        Completed = 2
    }
}
