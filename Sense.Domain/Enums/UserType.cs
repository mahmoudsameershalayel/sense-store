using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum UserType
    {
        [Display(Name = "مدير النظام")]
        Administrator = 1,       
        [Display(Name = "عميل")]
        Customer = 2,
        [Display(Name = "مشرف")]
        Supervisor = 3,
        [Display(Name = "دعم فني")]
        TechSupport = 4,
        [Display(Name = "مزود")]
        Provider = 5,
        [Display(Name = "مزود خدمة")]
        ServiceProvider = 6,
        [Display(Name = "مروج")]
        Promoter = 7
    }
}
