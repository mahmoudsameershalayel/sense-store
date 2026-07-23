using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CustomerDTOs
{
    public class CustomerRecentLogDto
    {
        public DateTime? Date { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
    }
}
