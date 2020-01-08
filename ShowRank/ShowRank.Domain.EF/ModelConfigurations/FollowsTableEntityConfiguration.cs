using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.EF.ModelConfigurations
{
    public class FollowsTableEntityConfiguration : IEntityTypeConfiguration<FollowsTable>
    {
        public void Configure(EntityTypeBuilder<FollowsTable> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);

            //builder.HasOne(c => c.IdOfTheOneWhoFollows);
            //builder.HasOne(c => c.IdOfWhoIsBeingFollowed);
        }
    }
}
