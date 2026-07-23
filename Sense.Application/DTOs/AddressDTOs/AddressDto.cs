using Sense.Application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AddressDTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
      /*  public string? Apartment { get; set; }
        public string? BuildingNo { get; set; }
        public string? FloorNo { get; set; }
        public string? FlatNo { get; set; }
        public string? FamousSign { get; set; } */
        public string? Neighborhood { get; set; }

        public string? LocationLong { get; set; }
        public string? LocationLat { get; set; }
        public string? Address { get; set; }


    }
}
