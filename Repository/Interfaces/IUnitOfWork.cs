using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }
        IPhotoRepository Photos { get; }

        Task CompleteAsync();
    }
}