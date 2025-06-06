﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateRentalMgmt.Data;

#nullable disable

namespace RealEstateRentalMgmt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250401131648_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RealEstateRentalMgmt.Models.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<double?>("BrokerageFee")
                        .HasColumnType("double")
                        .HasColumnName("brokeragefee");

                    b.Property<string>("CarFee")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("carfee");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("createdby");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("createddate");

                    b.Property<string>("DecorationTime")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("decorationtime");

                    b.Property<string>("Deposit")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("deposit");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("direction");

                    b.Property<long>("DistrictId")
                        .HasColumnType("bigint")
                        .HasColumnName("districtid");

                    b.Property<string>("ElectricityFee")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("electricityfee");

                    b.Property<long?>("FloorArea")
                        .HasColumnType("bigint")
                        .HasColumnName("floorarea");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("level");

                    b.Property<string>("LinkOfBuilding")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("linkofbuilding");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("managername");

                    b.Property<string>("ManagerPhone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("managerphonenumber");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("map");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("modifiedby");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("modifieddate");

                    b.Property<string>("MotorbikeFee")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("motorbikefee");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("note");

                    b.Property<long?>("NumberOfBasement")
                        .HasColumnType("bigint")
                        .HasColumnName("numberofbasement");

                    b.Property<string>("OvertimeFee")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("overtimefee");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("payment");

                    b.Property<long>("RentPrice")
                        .HasColumnType("bigint")
                        .HasColumnName("rentprice");

                    b.Property<string>("RentPriceDescription")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("rentpricedescription");

                    b.Property<string>("RentTime")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("renttime");

                    b.Property<string>("ServiceFee")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("servicefee");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("street");

                    b.Property<string>("Structure")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("structure");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ward");

                    b.Property<string>("WaterFee")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("waterfee");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("building", (string)null);
                });

            modelBuilder.Entity("RealEstateRentalMgmt.Models.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("district", (string)null);
                });

            modelBuilder.Entity("RealEstateRentalMgmt.Models.RentArea", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BuildingId")
                        .HasColumnType("bigint")
                        .HasColumnName("buildingid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("createdby");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("createddate");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("modifiedby");

                    b.Property<string>("ModifiedDate")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("modifieddate");

                    b.Property<long?>("Value")
                        .HasColumnType("bigint")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("rentarea", (string)null);
                });

            modelBuilder.Entity("RealEstateRentalMgmt.Models.Building", b =>
                {
                    b.HasOne("RealEstateRentalMgmt.Models.District", "District")
                        .WithMany("Buildings")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("RealEstateRentalMgmt.Models.RentArea", b =>
                {
                    b.HasOne("RealEstateRentalMgmt.Models.Building", "Building")
                        .WithMany("RentAreas")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("RealEstateRentalMgmt.Models.Building", b =>
                {
                    b.Navigation("RentAreas");
                });

            modelBuilder.Entity("RealEstateRentalMgmt.Models.District", b =>
                {
                    b.Navigation("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
