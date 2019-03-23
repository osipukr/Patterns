using Repository.Domain.Models;
using System.Collections.Generic;

namespace Repository.Domain.Repositories
{
    public interface IPhotoRepository : IRepository<Photo, string>
    {
        IEnumerable<Photo> GetPhotos(string albumId);

        // TODO: Additional logic for the current repository
    }
}