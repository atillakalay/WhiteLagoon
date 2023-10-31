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
        public DbSet<Amenity> Amenities { get; set; }

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
            modelBuilder.Entity<Amenity>().HasData(
          new Amenity
          {
              Id = 1,
              VillaId = 1,
              Name = "Private Pool"
          }, new Amenity
          {
              Id = 2,
              VillaId = 1,
              Name = "Microwave"
          }, new Amenity
          {
              Id = 3,
              VillaId = 1,
              Name = "Private Balcony"
          }, new Amenity
          {
              Id = 4,
              VillaId = 1,
              Name = "1 king bed and 1 sofa bed"
          },
          new Amenity
          {
              Id = 5,
              VillaId = 2,
              Name = "Private Plunge Pool"
          }, new Amenity
          {
              Id = 6,
              VillaId = 2,
              Name = "Microwave and Mini Refrigerator"
          }, new Amenity
          {
              Id = 7,
              VillaId = 2,
              Name = "Private Balcony"
          }, new Amenity
          {
              Id = 8,
              VillaId = 2,
              Name = "king bed or 2 double beds"
          },
          new Amenity
          {
              Id = 9,
              VillaId = 3,
              Name = "Private Pool"
          }, new Amenity
          {
              Id = 10,
              VillaId = 3,
              Name = "Jacuzzi"
          }, new Amenity
          {
              Id = 11,
              VillaId = 3,
              Name = "Private Balcony"
          });
        }
    }
}
