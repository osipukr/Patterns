using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Contexts.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Name).HasMaxLength(30);
            builder.Property(p => p.Description).HasMaxLength(50);

            builder.HasMany(a => a.Photos)
                   .WithOne(p => p.Album)
                   .HasForeignKey(p => p.AlbumId);
        }
    }
}