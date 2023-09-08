﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationsAPI;

#nullable disable

namespace VacationsAPI.Migrations
{
    [DbContext(typeof(VacationsDbContext))]
    partial class VacationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VacationsAPI.Models.Booking", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookingTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingTypeId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("VacationsAPI.Models.BookingType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaidTimeOff")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubtractDaysLeft")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookingTypes");
                });

            modelBuilder.Entity("VacationsAPI.Models.Booking", b =>
                {
                    b.HasOne("VacationsAPI.Models.BookingType", "BookingType")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingType");
                });

            modelBuilder.Entity("VacationsAPI.Models.BookingType", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
