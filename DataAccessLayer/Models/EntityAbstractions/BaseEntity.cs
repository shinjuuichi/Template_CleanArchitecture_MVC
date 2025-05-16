using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.EntityAbstractions
{
    public abstract class BaseEntity : Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
