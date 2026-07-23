using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ApplicationUserDTOs
{
    public class UploadUserImageDto
    {
        public string Id { get; set; }
        public IFormFile? Image { get; set; }
    }
}
