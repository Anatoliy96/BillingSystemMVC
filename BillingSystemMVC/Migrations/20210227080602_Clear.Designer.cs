﻿// <auto-generated />
using System;
using BillingSystemMVC.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillingSystemMVC.Migrations
{
    [DbContext(typeof(BillingSystemContext))]
    [Migration("20210227080602_Clear")]
    partial class Clear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BillingSystemMVC.Model.CashRegister", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.HasKey("IDNumber");

                    b.ToTable("CashRegisters");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Client", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("IPAdress")
                        .HasColumnType("text");

                    b.Property<DateTime>("Included")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("IDNumber");

                    b.HasIndex("TariffId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Payment", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Client")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.HasKey("IDNumber");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Profile", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("IDNumber");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.RoleMaster", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RollName")
                        .HasColumnType("text");

                    b.HasKey("IDNumber");

                    b.ToTable("RoleMasters");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Tariff", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("InternetSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

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

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProfileID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BillingSystemMVC.Model.Zone", b =>
                {
                    b.Property<int>("IDNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Owner")
                        .HasColumnType("text");

                    b.Property<string>("Tariff")
                        .HasColumnType("text");

                    b.Property<string>("Town")
                        .HasColumnType("text");

                    b.Property<string>("WorkingIPAdresses")
                        .HasColumnType("text");

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
                });
#pragma warning restore 612, 618
        }
    }
}
