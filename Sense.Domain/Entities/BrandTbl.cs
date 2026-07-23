using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class BrandTbl : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ModelTbl> ModelTbls { get; set; } = new List<ModelTbl>();
        public ICollection<ProductTbl> Products { get; set; } = new List<ProductTbl>();
        public ICollection<AppointmentTbl> Appointments { get; set; } = new List<AppointmentTbl>();

    }
}
