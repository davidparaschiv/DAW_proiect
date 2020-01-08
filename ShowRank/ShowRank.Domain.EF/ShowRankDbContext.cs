using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowRank.Domain.EF.ModelConfigurations;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.EF
{
    public class ShowRankDbContext : IdentityDbContext<Profile>
    {
        public ShowRankDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FollowsTableEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ToSeeListItemEntityConfiguration());
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<FollowsTable> FollowsTable { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ToSeeListItem> ToSeeListItems { get; set; }
    }
}
