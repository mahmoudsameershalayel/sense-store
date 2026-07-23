using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ModelTbl : BaseEntity
    {
        public string Name { get; set; }

        public int? BrandId { get; set; }
        public BrandTbl? Brand { get; set; }
        public ICollection<ProductTbl> Products { get; set; } = new List<ProductTbl>();
        public ICollection<AppointmentTbl> Appointments { get; set; } = new List<AppointmentTbl>();

    }
}
