using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class AddressTbl : BaseEntity
    {
        public string? City { get; set; }
        [StringLength(100)]
        public string? Street { get; set; }
        [StringLength(50)]
        public string? BuildingNo { get; set; }
        [StringLength(50)]
        public string? FloorNo { get; set; }
        [StringLength(50)]
        public string? FlatNo { get; set; }
        [StringLength(500)]
        public string? FamousSign { get; set; }
        [StringLength(100)]
        public string? Neighborhood { get; set; } 

        [StringLength(500)]
        public string? Address { get; set; }
        public string? Apartment { get; set; }
        public string? LocationLong { get; set; }
        public string? LocationLat { get; set; }

   

        public long CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }

        public ICollection<OrderTbl> OrderTbls { get; set; } = new List<OrderTbl>();


    }

}
