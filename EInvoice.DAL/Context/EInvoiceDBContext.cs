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

        #endregion

        #region Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Item
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(i => i.ItemID);
                entity.Property(i => i.Name).IsRequired().HasMaxLength(100);
                entity.Property(i => i.ItemCode).IsRequired();

                entity.HasMany(i => i.ItemTaxes)
                        .WithOne(it => it.Item)
                        .HasForeignKey(it => it.ItemId);
            });

            // Tax
            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(t => t.TaxID);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(50);
                entity.Property(t => t.TaxAmount).HasColumnType("decimal(18,2)");

                entity.HasMany(t => t.ItemTaxes)
                        .WithOne(it => it.Tax)
                        .HasForeignKey(it => it.TaxId);
            });

            // ItemTax
            modelBuilder.Entity<ItemTax>(entity =>
            {
                // Configure composite primary key
                entity.HasKey(it => it.ItemTaxID);
                
                entity.HasOne(it => it.Item)
                      .WithMany(i => i.ItemTaxes)
                      .HasForeignKey(it => it.ItemId);

                entity.HasOne(it => it.Tax)
                      .WithMany(t => t.ItemTaxes)
                      .HasForeignKey(it => it.TaxId);
            });

            // Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerID);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            // EInvoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceID);
                entity.Property(e => e.InvoiceCode).IsRequired();
                entity.Property(e => e.Type).IsRequired();

                entity.HasMany(e => e.InvoiceItems)
                      .WithOne(ii => ii.Invoice)
                      .HasForeignKey(ii => ii.InvoiceId);
            });

            // ImvoceItem
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(ii => ii.ItemInvoiceID);

                entity.Property(ii => ii.Amount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(ii => ii.Quantity).IsRequired();

                entity.HasOne(ii => ii.Item)
                      .WithMany()
                      .HasForeignKey(ii => ii.ItemId);

                entity.HasOne(ii => ii.Invoice)
                      .WithMany(i => i.InvoiceItems)
                      .HasForeignKey(ii => ii.InvoiceId);
            });

        }
        #endregion
    }
}
