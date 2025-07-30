﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    public DbSet<Resource> Resources { get; set; }
    public DbSet<ResourceBook> ResourceBooks { get; set; }

    // Fluent API configuration goes here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Resource configuration
        modelBuilder.Entity<Resource>()
            .HasKey(r => r.ResourceId);  // Primary key for the Resource table

        modelBuilder.Entity<Resource>()
            .Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(50);

       modelBuilder.Entity<Resource>()
            .Property(r => r.ResourceTypeId)
            .IsRequired();

        modelBuilder.Entity<Resource>()
            .Property(r => r.ResourceTopicId)
            .IsRequired();


            // ResourceBook configuration
        modelBuilder.Entity<ResourceBook>()
            .HasKey(b => b.Id);  // ResourceBook uses Id as its primary key

        modelBuilder.Entity<ResourceBook>()
            .HasOne(b => b.Resource)
            .WithOne()
            .HasForeignKey<ResourceBook>(b => b.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ResourceBook>()
            .Property(b => b.Author)
            .HasMaxLength(50);

        modelBuilder.Entity<ResourceBook>()
            .Property(b => b.Pages);

        modelBuilder.Entity<ResourceBook>()
            .Property(b => b.Cost)
            .HasColumnType("decimal(18,2)");  // This will store the Price as a decimal with 18 digits and 2 decimal places

            modelBuilder.Entity<ResourceBook>()
            .Property(b => b.PublishDate)
            .HasMaxLength(20);
    }
}
}
