using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Models;
using Repository.Repositories;

namespace Repository
{
    public sealed class Program
    {
        private static string ConnectionString => "Server=localhost;Database=repository-pattern3-db;Trusted_Connection=True;";

        public static async Task Main()
        {
            var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            var context = new AppDbContext(dbOptions);

            if (await context.Database.EnsureCreatedAsync())
            {
                await context.SeedAsync();
            }

            using var uow = new UnitOfWork(context);

            PrintAlbums(await uow.Albums.GetAll().ToListAsync());
            PrintPhotos(await uow.Photos.GetAll().ToListAsync());
        }

        #region Print Helpers

        private static void PrintAlbums(IEnumerable<Album> albums)
        {
            Console.WriteLine("Albums:");

            foreach (var album in albums)
            {
                Console.WriteLine($"Album | Id - {album.Id}");
                Console.WriteLine($"Album | Name - {album.Name}");
                Console.WriteLine($"Album | Description - {album.Description}\n");
            }
        }

        private static void PrintPhotos(IEnumerable<Photo> photos)
        {
            Console.WriteLine("Photos:");

            foreach (var photo in photos)
            {
                Console.WriteLine($"Photo | Id - {photo.Id}");
                Console.WriteLine($"Photo | Url - {photo.Url}");
                Console.WriteLine($"Photo | AlbumId - {photo.AlbumId}\n");
            }
        }

        #endregion
    }
}