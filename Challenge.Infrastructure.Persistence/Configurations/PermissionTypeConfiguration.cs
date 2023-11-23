using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Infrastructure.Persistence.Configurations
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).
            HasColumnType("VARCHAR(70)").
            HasColumnName("Description").
            IsRequired();
        }
    }
}
