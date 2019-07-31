using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories
{
    public class AlbumRepository : Repository<Album, string>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext context)
            : base(context)
        {
        }

        public IQueryable<Album> GetAllAlbumsWithPhotos() => 
            _context.Albums.Include(x => x.Photos);
    }
}