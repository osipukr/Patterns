using System;

namespace Repository.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }
        IPhotoRepository Photos { get; }
        IImageRepository Images { get; }

        void Complete();
    }
}