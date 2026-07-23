using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum ServiceType
    {
        [Display(Name = "صيانة فورية")]
        ImmediateMaintenance = 1,

        [Display(Name = "سمكرة")]
        BodyRepair = 2,

        [Display(Name = "كهرباء وبرمجة")]
        ElectricalProgramming = 3,

        [Display(Name = "إصلاح محرك")]
        EngineRepair = 4,

        [Display(Name = "إصلاح جير بوكس")]
        GearboxRepair = 5
    }
}
