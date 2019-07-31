using Microsoft.EntityFrameworkCore;
using Repository.Contexts.Configurations;
using Repository.Models;

namespace Repository.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AlbumConfiguration())
                   .ApplyConfiguration(new PhotoConfiguration());
        }
    }
}