using EInvoice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Context
{
    public class EInvoiceDBContext : DbContext
    {
        #region Constructors

        public EInvoiceDBContext()
        {
            
        }

        public EInvoiceDBContext(DbContextOptions<EInvoiceDBContext> options):base(options)
        {
            
        }

        #endregion

        #region DbSets
        public DbSet<Item> Items { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<InvoiceItemTax> InvoiceItemTaxes { get; set; }

        #endregion

        #region Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Item
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(i => i.ItemID);
                entity.Property(i => i.Name).IsRequired().HasMaxLength(100);
                entity.Property(i => i.Code).IsRequired();

                entity.HasMany(i => i.InvoiceItems)
                        .WithOne(ii => ii.Item)
                        .HasForeignKey(ii => ii.ItemId);
            });

            // Tax
            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(t => t.TaxID);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(50);
                entity.Property(t => t.Code).IsRequired();

                entity.HasMany(t => t.InvoiceItemTaxes)
                        .WithOne(iit => iit.Tax)
                        .HasForeignKey(it => it.InvoiceItemTaxID);
            });

            // InvoiceItemTaxes
            modelBuilder.Entity<InvoiceItemTax>(entity =>
            {
                entity.HasKey(it => it.InvoiceItemTaxID);
                entity.Property(t => t.TaxAmount).HasColumnType("decimal(18,2)");

                entity.HasOne(it => it.InvoiceItem)
                      .WithMany(i => i.InvoiceItemTaxes)
                      .HasForeignKey(it => it.InvoiceItemID);

                entity.HasOne(t => t.Tax)
                      .WithMany(it => it.InvoiceItemTaxes)
                      .HasForeignKey(it => it.TaxId);
            });

            // Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerID);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(i => i.Code).IsRequired();

                entity.HasMany(c => c.Invoices)
                        .WithOne(i => i.Customer)
                        .HasForeignKey(i => i.CustomerID)
                        .OnDelete(DeleteBehavior.SetNull);
            });

            // Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceID);
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Type).IsRequired();

                entity.HasMany(e => e.InvoiceItems)
                      .WithOne(ii => ii.Invoice)
                      .HasForeignKey(ii => ii.InvoiceId);
            });

            // InvoiceItem
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(ii => ii.InvoiceItemID);

                entity.Property(ii => ii.Amount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(ii => ii.Quantity).IsRequired();

                entity.HasOne(ii => ii.Item)
                      .WithMany(i => i.InvoiceItems)
                      .HasForeignKey(ii => ii.ItemId);

                entity.HasOne(ii => ii.Invoice)
                      .WithMany(i => i.InvoiceItems)
                      .HasForeignKey(ii => ii.InvoiceId);

            });

        }
        #endregion
    }
}
