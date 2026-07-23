using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AuthDTOs
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        public string? Password { get; set; }
    }
}
