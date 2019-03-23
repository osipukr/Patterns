using Microsoft.EntityFrameworkCore;
using Repository.Domain.Models;
using Repository.Domain.Repositories;
using Repository.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Persistence.Repositories
{
    public class PhotoRepository : Repository<Photo, string>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Photo> GetPhotos(string albumId)
        {
            return _context.Photos.Include(x => x.Album).Include(x => x.Image).Where(x => x.AlbumId.Equals(albumId));
        }
    }
}