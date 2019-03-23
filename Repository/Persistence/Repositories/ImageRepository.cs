using Repository.Domain.Models;
using Repository.Domain.Repositories;
using Repository.Persistence.Contexts;

namespace Repository.Persistence.Repositories
{
    public class ImageRepository : Repository<Image, string>, IImageRepository
    {
        public ImageRepository(AppDbContext contet)
            : base(contet)
        {
        }
    }
}