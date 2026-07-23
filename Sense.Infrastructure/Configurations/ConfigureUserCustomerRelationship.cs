using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Infrastructure.Configurations
{
    public class ConfigureUserCustomerRelationship : IEntityTypeConfiguration<CustomerTbl>
    {
        public void Configure(EntityTypeBuilder<CustomerTbl> builder)
        {
            builder.HasOne(c => c.ApplicationUser).WithOne().HasForeignKey<CustomerTbl>(c => c.ApplicationUserId);
        }
    }
}