using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Domain.Models;
using Repository.Domain.Repositories;
using Repository.Persistence.Contexts;

namespace Repository.Persistence.Repositories
{
    public class AlbumRepository : Repository<Album, string>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Album> GetAllAlbumsWithPhotos()
        {
            return _context.Albums.Include(x => x.Photos);
        }
    }
}