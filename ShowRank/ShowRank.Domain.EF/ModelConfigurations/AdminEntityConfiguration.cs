using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.EF.ModelConfigurations
{
    public class AdminEntityConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            // Id should be configured on root class (IdentityUser) automatically by Identity
            // Configuring it again here would cause an error when migrating

            // No need for below code
            //builder.HasKey(c => c.Id);
            //builder.HasIndex(c => c.Id);
        }
    }
}
