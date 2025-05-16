using DataAccessLayer.Models.EntityAbstractions;
using DataAccessLayer.Models.EntityAnnotations;

namespace DataAccessLayer.Models
{
    public class Product : AuditableEntity
    {
        [MessageRequired]
        [MessageMaxLength(255)]
        public string? Name { get; set; }

        [MessageRequired]
        [MessageMaxLength(1000)]
        public string? Description { get; set; }

        [NumberPositive]
        public double? Price { get; set; }

        [MessageRequired]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
