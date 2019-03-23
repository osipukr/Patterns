using Repository.Domain.Models;
using Repository.Persistence.Contexts;
using Repository.Persistence.Repositories;
using System;
using System.Linq;

namespace Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork(new AppDbContext()))
            {
                Console.WriteLine("Albums:");
                uow.Albums.GetAll().ToList().ForEach(album => PrintAlbum(album));

                Console.WriteLine("Photos:");
                uow.Photos.GetAll().ToList().ForEach(photo => PrintPhoto(photo));

                Console.WriteLine("Images:");
                uow.Images.GetAll().ToList().ForEach(image => PrintImage(image));
            }

            Console.ReadKey();
        }

        #region PrintHelper
        private static void PrintAlbum(Album album)
        {
            Console.WriteLine($"Album | Id - {album.Id}");
            Console.WriteLine($"Album | Name - {album.Name}");
            Console.WriteLine($"Album | Description - {album.Description}\n");
        }

        private static void PrintPhoto(Photo photo)
        {
            Console.WriteLine($"Photo | Id - {photo.Id}");
            Console.WriteLine($"Photo | ImageId - {photo.ImageId}\n");
        }

        private static void PrintImage(Image image)
        {
            Console.WriteLine($"Image | Id - {image.Id}");
            Console.WriteLine($"Image | Url - {image.Url}");
            Console.WriteLine($"Image | PhotoId - {image.PhotoId}\n");
        }
        #endregion
    }
}