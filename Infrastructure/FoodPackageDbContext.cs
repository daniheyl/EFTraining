using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FoodPackageDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null;

    public DbSet<PackageDetail> PackageDetails { get; set; } = null;

    public DbSet<FoodPackage> FoodPackages { get; set; } = null;

    public FoodPackageDbContext(DbContextOptions<FoodPackageDbContext> contextOptions) : base(contextOptions)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=FoodPackage;Trusted_Connection=True");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Hamburger", ContainsAlcohol = false, Picture = "NA" },
            new Product() { Id = 2, Name = "Bier", ContainsAlcohol = true, Picture = "NA" },
            new Product() { Id = 3, Name = "Danoontje", ContainsAlcohol = false, Picture = "NA" });

    }

}
