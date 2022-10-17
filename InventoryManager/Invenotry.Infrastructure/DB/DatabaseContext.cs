using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invenotry.Infrastructure
{
    public class DatabaseContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InventoryDb");
        }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(
                o =>
                {
                    o.HasKey(x => x.Id);
                    o.OwnsOne( x => x.Name, conf => { conf.Property(p => p.Value).HasColumnName("Name"); });
                    o.OwnsOne(x => x.ExpirationDate, conf => { conf.Property(p => p.Value).HasColumnName("ExpirationDate"); });
                    o.OwnsOne(x => x.Type, conf => { conf.Property(p => p.Value).HasColumnName("Type"); });
                });
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
