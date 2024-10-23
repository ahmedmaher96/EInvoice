﻿// <auto-generated />
using System;
using EInvoice.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EInvoice.DAL.Migrations
{
    [DbContext(typeof(EInvoiceDBContext))]
    [Migration("20241023113414_CustomerID")]
    partial class CustomerID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EInvoice.DAL.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeInssured")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("InvoiceID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.InvoiceItem", b =>
                {
                    b.Property<int>("InvoiceItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceItemID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InvoiceItemID");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.InvoiceItemTax", b =>
                {
                    b.Property<int>("InvoiceItemTaxID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceItemTaxID"));

                    b.Property<int?>("InvoiceItemID")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TaxId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceItemTaxID");

                    b.HasIndex("InvoiceItemID");

                    b.HasIndex("TaxId");

                    b.ToTable("InvoiceItemTaxes");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ItemID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Tax", b =>
                {
                    b.Property<int>("TaxID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TaxID");

                    b.ToTable("Taxs");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Invoice", b =>
                {
                    b.HasOne("EInvoice.DAL.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.InvoiceItem", b =>
                {
                    b.HasOne("EInvoice.DAL.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EInvoice.DAL.Models.Item", "Item")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Invoice");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.InvoiceItemTax", b =>
                {
                    b.HasOne("EInvoice.DAL.Models.InvoiceItem", "InvoiceItem")
                        .WithMany("InvoiceItemTaxes")
                        .HasForeignKey("InvoiceItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EInvoice.DAL.Models.Tax", "Tax")
                        .WithMany("InvoiceItemTaxes")
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("InvoiceItem");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.InvoiceItem", b =>
                {
                    b.Navigation("InvoiceItemTaxes");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Item", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("EInvoice.DAL.Models.Tax", b =>
                {
                    b.Navigation("InvoiceItemTaxes");
                });
#pragma warning restore 612, 618
        }
    }
}
