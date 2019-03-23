using System.Collections.Generic;

namespace Repository.Domain.Models
{
    public class Album : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}