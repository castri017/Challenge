using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EmployeeForename).
            HasColumnType("VARCHAR(70)").
            HasColumnName("EmployeeForename").
            IsRequired();

            builder.Property(e => e.EmployeeSurname).
            HasColumnType("VARCHAR(70)").
            HasColumnName("EmployeeSurname").
            IsRequired();

            builder.Property(e => e.PermissionType).
            HasColumnType("INTEGER").
            HasColumnName("PermissionType").
            IsRequired();

            builder.Property(e => e.PermissionDate).
            HasColumnType("datetime2(7)").
            HasColumnName("PermissionDate").
            IsRequired();
        }
    }
}
