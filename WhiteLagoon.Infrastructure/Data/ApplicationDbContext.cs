using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Lüks Deniz Villası",
                    Description = "Bu lüks deniz villası, harika bir manzaraya sahiptir ve 8 kişiye kadar konaklama imkanı sunar.",
                    Price = 500.00,
                    Sqft = 3000,
                    Occupancy = 8,
                    ImageUrl = "https://example.com/villa1.jpg",
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Name = "Orman Kenarı Villa",
                    Description = "Ormanın huzurlu atmosferinde bulunan bu villa, doğa severler için mükemmel bir seçenektir.",
                    Price = 400.00,
                    Sqft = 2500,
                    Occupancy = 6,
                    ImageUrl = "https://example.com/villa2.jpg",
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now
                },
                new Villa
                {
                    Id = 3,
                    Name = "Şehir Merkezi Stüdyo Dairesi",
                    Description = "Şehir merkezinde yer alan bu stüdyo daire, iş seyahati yapanlar için idealdir.",
                    Price = 100.00,
                    Sqft = 800,
                    Occupancy = 2,
                    ImageUrl = "https://example.com/villa3.jpg",
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now
                });

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 104,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 203,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = 3,
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = 3,
                },
                new VillaNumber
                {
                    Villa_Number = 204,
                    VillaId = 2,
                });
        }
    }
}
