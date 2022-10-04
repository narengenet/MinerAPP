﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinerAPP.Infrastructure.Contexts;

#nullable disable

namespace MinerAPP.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MinerAPP.Core.Domain.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Points")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileMediaURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a276ae1b-cf15-4318-ac35-985c58e40ed9"),
                            Cellphone = "09394125130",
                            Family = "Jouybari",
                            IsActivated = false,
                            Name = "Sina",
                            Points = 0L,
                            ProfileMediaURL = "uploads/2022/9/sina2.jpg",
                            Username = "sinful"
                        },
                        new
                        {
                            Id = new Guid("8fe7656a-0c88-45db-895d-e2d262bbe4c1"),
                            Cellphone = "09111769591",
                            Family = "پردلان",
                            IsActivated = false,
                            Name = "محسن",
                            Points = 0L,
                            ProfileMediaURL = "uploads/2022/9/99.jpg",
                            Username = "vinona"
                        },
                        new
                        {
                            Id = new Guid("86ff82c4-a1fe-449c-a7d5-4704cf8444eb"),
                            Cellphone = "09163681249",
                            Family = "یاراحمدی",
                            IsActivated = false,
                            Name = "سپیده",
                            Points = 0L,
                            ProfileMediaURL = "uploads/2022/9/photo.jpg",
                            Username = "sepideh"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
