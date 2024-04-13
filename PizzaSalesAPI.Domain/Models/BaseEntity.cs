using System.ComponentModel.DataAnnotations;

namespace PissaSalesAPI.Domain.Models
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
