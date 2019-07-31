using Microsoft.EntityFrameworkCore;
using System.Linq;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories
{
    public class PhotoRepository : Repository<Photo, string>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext context)
            : base(context)
        {
        }

        public IQueryable<Photo> GetPhotos(string albumId) =>
            _context.Photos.Include(x => x.Album)
                .Where(x => x.AlbumId.Equals(albumId));
    }
}