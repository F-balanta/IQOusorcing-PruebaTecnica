using System.ComponentModel.DataAnnotations;

namespace IQOUTSOURCING.Domain.Entities.Base
{
    public class BaseEntity : Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
