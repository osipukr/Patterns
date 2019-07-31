using System.Collections.Generic;

namespace Repository.Models
{
    public class Album : BaseModel<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}