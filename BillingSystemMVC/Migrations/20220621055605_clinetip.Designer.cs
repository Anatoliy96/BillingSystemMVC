﻿// <auto-generated />
using System;
using BillingSystemMVC.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BillingSystemMVC.Migrations
{
    [DbContext(typeof(BillingSystemContext))]
    [Migration("20220621055605_clinetip")]
    partial class clinetip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BillingSystemMVC.Model.CashRegister", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("CashRegisters");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Client", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Included")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("IDNumber");

                    b.HasIndex("TariffId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.ClientLog", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("ClientLog");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.IPAdress", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("IPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("IPS");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Payment", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Client")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("IDNumber");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Profile", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.RoleMaster", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<string>("RollName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("RoleMasters");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Tariff", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<int>("InternetSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("IDNumber");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.UserRoleMapping", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("IDNumber");

                    b.ToTable("UserRoleMappings");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Users", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Zone", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNumber"), 1L, 1);

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tariff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingIPAdresses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Client", b =>
                {
                    b.HasOne("BillingSystemMVC.Model.Tariff", "ClientTarif")
                        .WithMany("Clients")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillingSystemMVC.Model.Zone", "ClientZone")
                        .WithMany("Clients")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientTarif");

                    b.Navigation("ClientZone");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Tariff", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Zone", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
