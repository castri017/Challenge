﻿// <auto-generated />
using System;
using Challenge.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ChallengeContext))]
    [Migration("20231120115817_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Challenge.Domain.core.Aggregates.PermissionAggregate.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("EmployeeForename")
                        .IsRequired()
                        .HasColumnType("VARCHAR(70)")
                        .HasColumnName("EmployeeForename");

                    b.Property<string>("EmployeeSurname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(70)")
                        .HasColumnName("EmployeeSurname");

                    b.Property<DateTime>("PermissionDate")
                        .HasColumnType("datetime2(7)")
                        .HasColumnName("PermissionDate");

                    b.Property<int>("PermissionType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("PermissionType");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Challenge.Domain.core.Aggregates.PermissionAggregate.PermissionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(70)")
                        .HasColumnName("Description");

                    b.HasKey("Id");

                    b.ToTable("PermissionType");
                });
#pragma warning restore 612, 618
        }
    }
}
