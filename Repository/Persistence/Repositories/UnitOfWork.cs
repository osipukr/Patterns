using Repository.Domain.Repositories;
using Repository.Persistence.Contexts;

namespace Repository.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Albums = new AlbumRepository(_context);
            Photos = new PhotoRepository(_context);
            Images = new ImageRepository(_context);
        }

        public IAlbumRepository Albums { get; private set; }
        public IPhotoRepository Photos { get; private set; }
        public IImageRepository Images { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}