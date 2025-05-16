using DataAccessLayer.Models.EntityAbstractions;
using DataAccessLayer.Models.EntityAnnotations;

namespace DataAccessLayer.Models
{
    public class Category : BaseEntity
    {
        [MessageRequired]
        [MessageMaxLength(255)]
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
