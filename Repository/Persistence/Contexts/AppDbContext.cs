using Microsoft.EntityFrameworkCore;
using Repository.Domain.Models;

namespace Repository.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            AlbumsCreating(builder);
            PhotosCreating(builder);
            ImagesCreating(builder);
        }

        #region ModelsCreating
        private void AlbumsCreating(ModelBuilder builder)
        {
            builder.Entity<Album>().HasKey(p => p.Id);
            builder.Entity<Album>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Album>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<Album>().Property(p => p.Description).HasMaxLength(50);
            builder.Entity<Album>().HasMany(p => p.Photos).WithOne(p => p.Album).HasForeignKey(p => p.AlbumId);

            builder.Entity<Album>().HasData
            (
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
            );
        }

        private void PhotosCreating(ModelBuilder builder)
        {
            builder.Entity<Photo>().HasKey(p => p.Id);
            builder.Entity<Photo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Photo>().HasOne(p => p.Image).WithOne(p => p.Photo).HasForeignKey<Image>(p => p.PhotoId);

            builder.Entity<Photo>().HasData
            (
                new Photo
                {
                    Id = "462e23ca-f944-49f2-bcb5-4be963b1a327",
                    AlbumId = "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
                    ImageId = "1eca8c4c-c7c0-447f-9287-f451c0520c28"
                },

                new Photo
                {
                    Id = "e2193657-e924-4967-99ce-adc3d0daa9de",
                    AlbumId = "3fdaec2a-be17-4c3c-b50e-72ff0eec2440",
                    ImageId = "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845"
                }
            );
        }

        private void ImagesCreating(ModelBuilder builder)
        {
            builder.Entity<Image>().HasKey(p => p.Id);
            builder.Entity<Image>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Image>().Property(p => p.Url);
            builder.Entity<Image>().HasOne(p => p.Photo).WithOne(p => p.Image).HasForeignKey<Photo>(p => p.ImageId);

            builder.Entity<Image>().HasData
            (
                new Image
                {
                    Id = "1eca8c4c-c7c0-447f-9287-f451c0520c28",
                    Url = "https://avatars.mds.yandex.net/get-pdb/1105309/b26948f0-22ce-41a3-a690-770e9cbf92ce/s1200",
                    PhotoId = "462e23ca-f944-49f2-bcb5-4be963b1a327"
                },

                new Image
                {
                    Id = "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845",
                    Url = "https://avatars.mds.yandex.net/get-pdb/805781/e9f31bb4-e65d-4ccf-8a5f-36b74d8a75be/s1200",
                    PhotoId = "e2193657-e924-4967-99ce-adc3d0daa9de"
                }
            );
        }
        #endregion
    }
}