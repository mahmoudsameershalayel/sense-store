using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AuthDTOs
{
    public class UserForRegisterDto
    {

        [Required(ErrorMessage = "الإسم الأول مطلوب")]
        [StringLength(50, ErrorMessage = "الاسم الأول لا يمكن أن يتجاوز 50 حرفًا.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "إسم العائلة مطلوب")]
        [StringLength(50, ErrorMessage = "الاسم الأخير لا يمكن أن يتجاوز 50 حرفًا.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "يجب أن تحتوي كلمة المرور على 6 أحرف على الأقل.")]
        public string? Password { get; set; }

        [RegularExpression(@"^(?:\+9665|05)[0-9]{8}$", ErrorMessage = "رقم الهاتف غير صالح")]
        public string? PhoneNumber { get; set; }
    }
}
