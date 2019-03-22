using Repository.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Domain.Repositories
{
    public interface IPhotoRepository : IRepository<Photo, string>
    {
        Task<IEnumerable<Photo>> GetPhotosAsync(string albumId);
    }
}