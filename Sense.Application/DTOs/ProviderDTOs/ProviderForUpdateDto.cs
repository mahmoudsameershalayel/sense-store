using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ProviderDTOs
{
    public class ProviderForUpdateDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LogoURL { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
