using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.EF.ModelConfigurations
{
    public class ToSeeListItemEntityConfiguration : IEntityTypeConfiguration<ToSeeListItem>
    {
        public void Configure(EntityTypeBuilder<ToSeeListItem> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);

            //builder.HasOne(c => c.IdOfProfile);
            //builder.HasOne(c => c.IdOfProfileWhoSharedTheOpinion);
        }
    }
}
