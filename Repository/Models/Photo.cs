namespace Repository.Models
{
    public class Photo : BaseModel<string>
    {
        public string Url { get; set; }

        public virtual string AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}