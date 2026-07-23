using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CityTbl : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى إدخال إسم المدينة")]
        public string Name { get; set; } = "";
    }
}
