using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Challenge.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Challenge.Infrastructure.Persistence.Context
{
    public class ChallengeContext : DbContext
    {

        public ChallengeContext(DbContextOptions option)
           : base(option)
        {
        }

        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());

        }
    }

}
