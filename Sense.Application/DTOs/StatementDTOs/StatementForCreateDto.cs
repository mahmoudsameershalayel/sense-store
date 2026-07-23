using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.StatementDTOs
{
    public class StatementForCreateDto
    {
        public string Text { get; set; }
        public string? IconClass { get; set; }
        public int SortOrder { get; set; }
    }
}
