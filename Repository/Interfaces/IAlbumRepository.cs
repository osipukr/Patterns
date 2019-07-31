using System.Linq;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IAlbumRepository : IRepository<Album, string>
    {
        IQueryable<Album> GetAllAlbumsWithPhotos();
    }
}