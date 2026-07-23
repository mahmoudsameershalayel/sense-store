using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ProviderDTOs
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public string? LogoURL { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
