﻿// <auto-generated />
using System;
using IceCreamShopDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IceCreamShopDatabaseImplement.Migrations
{
    [DbContext(typeof(IceCreamShopDatabase))]
    [Migration("20230224163325_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Additive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditiveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Additives");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.IceCream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IceCreamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("IceCreams");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.IceCreamAdditive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdditiveId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("IceCreamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdditiveId");

                    b.HasIndex("IceCreamId");

                    b.ToTable("IceCreamAdditives");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("IceCreamId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.IceCreamAdditive", b =>
                {
                    b.HasOne("IceCreamShopDatabaseImplement.Models.Additive", "Additive")
                        .WithMany("IceCreamAdditives")
                        .HasForeignKey("AdditiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IceCreamShopDatabaseImplement.Models.IceCream", "IceCream")
                        .WithMany("Additives")
                        .HasForeignKey("IceCreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Additive");

                    b.Navigation("IceCream");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Additive", b =>
                {
                    b.Navigation("IceCreamAdditives");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.IceCream", b =>
                {
                    b.Navigation("Additives");
                });
#pragma warning restore 612, 618
        }
    }
}
