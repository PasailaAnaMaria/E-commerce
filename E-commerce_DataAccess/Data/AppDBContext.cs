
using E_commerce_Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_commerce_DataAccess.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name="Action",DisplayOrder=1},
                new Category { Id = 2, Name = "Romance", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    Id=1,
                    Title="Top Gun",
                    Author="Tom Cruis",
                    Description="Army pilots",
                    ISBN="F5435354bjh",
                    ListPrice=25,
                    Price=25,
                    Price50=26,
                    Price100=30,
                    CategoryId=1,
                    ImageUrl="",
                },
            new Product
            {
                Id = 2,
                Title = "Titanic",
                Author = "Leonardo D",
                Description = " The most bigger movie of all time",
                ISBN = "F5498754NN",
                ListPrice = 35,
                Price = 75,
                Price50 = 66,
                Price100 = 50,
                CategoryId=2,
                ImageUrl = "",
            },
            new Product
            {
                Id = 3,
                Title = "Marvel",
                Author = "D.B.",
                Description = "Disney",
                ISBN = "F5435354AAA",
                ListPrice = 29,
                Price = 28,
                Price50 = 26,
                Price100 = 31,
                CategoryId = 3,
                ImageUrl = "",
            },
            new Product
            {
                Id = 4,
                Title = "Thor",
                Author = "Chris T",
                Description = "Disney",
                ISBN = "F54353VYGJH",
                ListPrice = 15,
                Price = 65,
                Price50 = 36,
                Price100 = 36,
                CategoryId=1,
                ImageUrl = "",
            },
            new Product
            {
                Id = 5,
                Title = "Last Christmas",
                Author = "T.Cris",
                Description = "Love Santa",
                ISBN = "F543532528A",
                ListPrice = 15,
                Price = 15,
                Price50 = 16,
                Price100 =20,
                CategoryId=2,
                ImageUrl = "",
            },
            new Product
            {
                Id = 6,
                Title = "The Idol",
                Author = "L.Deep",
                Description = "Dancer ,love, discovery",
                ISBN = "F543535MM55",
                ListPrice = 25,
                Price = 25,
                Price50 = 26,
                Price100 = 30,
                CategoryId=3,
                ImageUrl = "",
            });
        }

    }
}
