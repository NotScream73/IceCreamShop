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
    [Migration("20230419172924_AddNullableMessage")]
    partial class AddNullableMessage
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

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
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

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Implementer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImplementerFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<int>("WorkExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Implementers");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ClientId");

                    b.ToTable("MessageInfos");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("IceCreamId")
                        .HasColumnType("int");

                    b.Property<int?>("ImplementerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("IceCreamId");

                    b.HasIndex("ImplementerId");

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

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.HasOne("IceCreamShopDatabaseImplement.Models.Client", "Client")
                        .WithMany("MessageInfos")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("IceCreamShopDatabaseImplement.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IceCreamShopDatabaseImplement.Models.IceCream", "IceCream")
                        .WithMany("Orders")
                        .HasForeignKey("IceCreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IceCreamShopDatabaseImplement.Models.Implementer", "Implementer")
                        .WithMany("Orders")
                        .HasForeignKey("ImplementerId");

                    b.Navigation("Client");

                    b.Navigation("IceCream");

                    b.Navigation("Implementer");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Additive", b =>
                {
                    b.Navigation("IceCreamAdditives");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("MessageInfos");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.IceCream", b =>
                {
                    b.Navigation("Additives");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("IceCreamShopDatabaseImplement.Models.Implementer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
