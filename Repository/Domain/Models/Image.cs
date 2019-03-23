namespace Repository.Domain.Models
{
    public class Image : BaseModel
    {
        public string Url { get; set; }
        public string PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}