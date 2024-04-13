using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.Domain.Models
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
