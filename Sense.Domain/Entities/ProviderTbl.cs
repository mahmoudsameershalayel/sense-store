using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sense.Domain.DBEntities
{
    public class ProviderTbl : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUserTbl? ApplicationUser { get; set; }

        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public string? LogoURL { get; set; }
        public string? PhoneNumber { get; set; }
        [MaxLength(100)]
        public string? BusinessCategoryKey { get; set; }

        [MaxLength(100)]
        public string? StorefrontTemplateKey { get; set; }

        public ICollection<ProductTbl> Products { get; set; } = new List<ProductTbl>();
    }
}
