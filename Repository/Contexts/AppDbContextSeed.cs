using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Contexts
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(this AppDbContext context)
        {
            try
            {
                if (!await context.Albums.AnyAsync())
                {
                    await context.Albums.AddRangeAsync(GetPreconfiguredAlbums());
                    await context.SaveChangesAsync();
                }

                if (!await context.Photos.AnyAsync())
                {
                    await context.Photos.AddRangeAsync(GetPreconfiguredPhotos());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static IEnumerable<Album> GetPreconfiguredAlbums() =>
            new[]
            {
                new Album
                {
                    Id = "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
                    Name = "Album 1",
                    Description = "Desc 1"
                },

                new Album
                {
                    Id = "b392f290-0e40-44a5-962b-4093cc31f65d",
                    Name = "Album 2",
                    Description = "Desc 2 new"
                }
            };

        private static IEnumerable<Photo> GetPreconfiguredPhotos() =>
            new[]
            {
                new Photo
                {
                    Url = "https://avatars.mds.yandex.net/get-pdb/805781/e9f31bb4-e65d-4ccf-8a5f-36b74d8a75be/s1200",
                    AlbumId = "3fdaec2a-be17-4c3c-b50e-72ff0eec2440"
                },

                new Photo
                {
                    Url = "https://avatars.mds.yandex.net/get-pdb/1105309/b26948f0-22ce-41a3-a690-770e9cbf92ce/s1200",
                    AlbumId = "3fdaec2a-be17-4c3c-b50e-72ff0eec2440"
                }
            };
    }
}