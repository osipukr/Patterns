using Repository.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Domain.Repositories
{
    public interface IAlbumRepository : IRepository<Album, string>
    {
        Task<IEnumerable<Album>> GetAlbumsAsync(string userId);
        Task<Album> GetAlbumAsync(string albumId, string userId);
    }
}