using EFTraining.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTraining.data
{
    public class FoodPackageContext : DbContext
    {
        public DbSet<Product> products { get; set; } = null;

        public DbSet<PackageDetail> PackageDetails { get; set; } = null;

        public DbSet<FoodPackage> FoodPackages { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }
    }
}
