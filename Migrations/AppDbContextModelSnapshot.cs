﻿// <auto-generated />
using System;
using CarQuery__Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarQuery__Test.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarQuery__Test.Domain.Models.Car", b =>
                {
                    b.Property<int>("idCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCar"));

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("color")
                        .HasColumnType("tinyint");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("idCar");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarQuery__Test.Domain.Models.Sale", b =>
                {
                    b.Property<int>("idSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSale"));

                    b.Property<DateTime>("DthRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("Fk_IdCar")
                        .HasColumnType("int");

                    b.Property<int>("Fk_IdClient")
                        .HasColumnType("int");

                    b.Property<int>("Fk_IdSeller")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idSale");

                    b.HasIndex("Fk_IdCar");

                    b.HasIndex("Fk_IdClient");

                    b.HasIndex("Fk_IdSeller");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CarQuery__Test.Domain.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"));

                    b.Property<DateOnly>("birth")
                        .HasColumnType("date");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("sex")
                        .HasColumnType("tinyint");

                    b.Property<byte>("userType")
                        .HasColumnType("tinyint");

                    b.HasKey("idUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarQuery__Test.Domain.Models.Sale", b =>
                {
                    b.HasOne("CarQuery__Test.Domain.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("Fk_IdCar")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CarQuery__Test.Domain.Models.User", "Client")
                        .WithMany()
                        .HasForeignKey("Fk_IdClient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CarQuery__Test.Domain.Models.User", "Seller")
                        .WithMany()
                        .HasForeignKey("Fk_IdSeller")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Seller");
                });
#pragma warning restore 612, 618
        }
    }
}
