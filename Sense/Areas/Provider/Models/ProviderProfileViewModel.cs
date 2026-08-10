using System.ComponentModel.DataAnnotations;
using Sense.Application.DTOs.AuthDTOs;

namespace Sense.Areas.Provider.Models
{
    public class ProviderProfileViewModel
    {
        public UserDto? User { get; set; }

        [Required(ErrorMessage = "وصف النشاط التجاري مطلوب.")]
        [StringLength(3000, ErrorMessage = "وصف النشاط التجاري لا يمكن أن يتجاوز 3000 حرف.")]
        [Display(Name = "وصف النشاط التجاري")]
        public string BusinessDescription { get; set; } = string.Empty;
    }
}
