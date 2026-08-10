using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum PartnerOfferType
    {
        [Display(Name = "خدمة")]
        Service = 1,
        [Display(Name = "منتج")]
        Product = 2
    }
}
