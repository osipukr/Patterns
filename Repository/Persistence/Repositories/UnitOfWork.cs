using Repository.Domain.Repositories;
using Repository.Persistence.Contexts;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IAlbumRepository _album;
        private readonly IPhotoRepository _photo;
        private readonly IImageRepository _image;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAlbumRepository Albums => _album ?? new AlbumRepository(_context);
        public IPhotoRepository Photos => _photo ?? new PhotoRepository(_context);
        public IImageRepository Images => _image ?? new ImageRepository(_context);

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}