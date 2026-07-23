using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum CashbackType
    {
        [Display(Name = "قيمة ثابتة")]
        Fixed = 1,
        [Display(Name = "نسبة مئوية")]
        Percentage = 2
    }
}
