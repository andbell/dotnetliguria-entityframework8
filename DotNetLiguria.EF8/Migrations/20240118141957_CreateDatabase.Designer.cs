﻿// <auto-generated />
using System.Collections.Generic;
using DotNetLiguria.EF8;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetLiguria.EF8.Migrations
{
    [DbContext(typeof(EF8Context))]
    [Migration("20240118141957_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNetLiguria.EF8.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(340)
                        .HasColumnType("nvarchar(340)");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "DotNetLiguria.EF8.Models.Customer.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line1")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("DotNetLiguria.EF8.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contents")
                        .HasMaxLength(340)
                        .HasColumnType("nvarchar(340)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("BillingAddress", "DotNetLiguria.EF8.Models.Order.BillingAddress#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line1")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("ShippingAddress", "DotNetLiguria.EF8.Models.Order.ShippingAddress#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line1")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(max)");
                        });

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("DotNetLiguria.EF8.Models.Order", b =>
                {
                    b.HasOne("DotNetLiguria.EF8.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DotNetLiguria.EF8.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
