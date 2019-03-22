namespace Repository.Domain.Models
{
    public class Photo : BaseModel
    {
        public string AlbumId { get; set; }
        public Album Album { get; set; }

        public string ImageId { get; set; }
        public Image Image { get; set; }
    }
}