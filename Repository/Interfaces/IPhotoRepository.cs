using System.Linq;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo, string>
    {
        IQueryable<Photo> GetPhotos(string albumId);
    }
}