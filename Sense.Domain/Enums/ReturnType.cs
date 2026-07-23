using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum ReturnType
    {
        [Display(Name = "نقاط")]
        Points = 1,
        [Display(Name = "رصيد في المحفظة")]
        CashOnWallet = 2
    }
}
