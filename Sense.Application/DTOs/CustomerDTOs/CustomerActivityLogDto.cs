using Sense.Application.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CustomerDTOs
{
    public class CustomerActivityLogDto
    {
        public int Id { get; set; }
        public UserDto Customer { get; set; }

        public string? Description { get; set; }
        public string? ActivityType { get; set; }
        public string? CreatedAt { get; set; }
    }
}
