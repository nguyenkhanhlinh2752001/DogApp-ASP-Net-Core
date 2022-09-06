using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DogApp.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasOne<Category>(d => d.Category)
                .WithMany(c => c.Dogs)
                .HasForeignKey(d => d.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany<Dog>(g => g.Dogs)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Dog>()
                .HasOne<Owner>(d => d.Owner)
                .WithMany(c => c.Dogs)
                .HasForeignKey(d => d.OwnerId);

            modelBuilder.Entity<Owner>()
                .HasMany<Dog>(g => g.Dogs)
                .WithOne(s => s.Owner)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        
        
    }
}
