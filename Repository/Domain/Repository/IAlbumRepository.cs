using Repository.Domain.Models;
using System.Collections.Generic;

namespace Repository.Domain.Repositories
{
    public interface IAlbumRepository : IRepository<Album, string>
    {
        // TODO: Additional logic for the current repository

        IEnumerable<Album> GetAllAlbumsWithPhotos();
    }
}