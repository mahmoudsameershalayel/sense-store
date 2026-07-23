using Sense.Application.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ModelDTOs
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public BrandDto? Brand { get; set; }
    }
}
