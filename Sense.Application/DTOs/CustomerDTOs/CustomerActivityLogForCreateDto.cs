using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CustomerDTOs
{
    public class CustomerActivityLogForCreateDto
    {
        public int CustomerId { get; set; }

        public string? Description { get; set; }
        public CustomerActivityType? ActivityType { get; set; }
    }
}
