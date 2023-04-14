using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bibliotheek.Model
{
    public class LibraryContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=LibraryDatabase;");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "J K Rolling"
                },
                new Author
                {
                    Id = 2,
                    Name = "Suzanne Coolins"
                },
                new Author
                {
                    Id = 3,
                    Name = "AE Sports"                    
                }
                );
            builder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Harry Pooter book 1",
                    Type = ItemType.Boek,
                },
                new Item
                {
                    Id = 2,
                    Name = "Harry Pooter book 2",
                    Type = ItemType.Boek,
                },
                new Item
                {
                    Id = 3,
                    Name = "Hungry Games movie 1",
                    Type = ItemType.DVD,
                },
                new Item
                {
                    Id = 4,
                    Name = "Hungry Games movie 3",
                    Type = ItemType.DVD,
                },
                new Item
                {
                    Id = 5,
                    Name = "Fifa 23",
                    Type = ItemType.Spel,
                }
                );

            builder.Entity<Author>().HasMany(a => a.Item).WithMany(i => i.Author).UsingEntity(pivotTable =>
            pivotTable.HasData(
                new { AuthorId = 1, ItemId = 1},
                new { AuthorId = 1, ItemId = 2},
                new { AuthorId = 2, ItemId = 3},
                new { AuthorId = 2, ItemId = 4},
                new { AuthorId = 3, ItemId = 5}
                )
            );
        }
    }
}
