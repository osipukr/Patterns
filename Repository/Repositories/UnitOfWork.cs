using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Albums = new AlbumRepository(_context);
            Photos = new PhotoRepository(_context);
        }

        public IAlbumRepository Albums { get; private set; }
        public IPhotoRepository Photos { get; private set; }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}