using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CategoryTbl  : BaseEntity
    {
        public string? Name { get; set; }
        public string? ImageURL { get; set; }

        public ICollection<ProductTbl> Products { get; set; } = new List<ProductTbl>();   
    }
}
